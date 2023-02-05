using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using static Languages;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance { get; private set; }

    [SerializeField] private PlayerData _playerData;

    public static UnityEvent<string> OnPlayerDataRecived = new UnityEvent<string>();
    public static UnityEvent<string> OnLanguageRecived = new UnityEvent<string>();
    public static UnityEvent OnPlayerDataSaved = new UnityEvent();
    public static UnityEvent OnVideoAdvRewarded = new UnityEvent();

    [DllImport("__Internal")]
    private static extern void SavePlayerDataExtern(string data);

    [DllImport("__Internal")]
    private static extern void GetPlayerDataExtern();

    [DllImport("__Internal")]
    private static extern void GetLanguageExtern();

    [DllImport("__Internal")]
    private static extern void ShowVideoAdvExtern();

    [DllImport("__Internal")]
    private static extern void ShowFeedbackExtern();

    public void SavePlayerData()
    {
        string data = JsonConvert.SerializeObject(_playerData);
        SavePlayerDataExtern(data);
    }

    public void SavePlayerDataCallBack(string result)
    {
        SaveSystem.SavePlayerPrefs(SaveSystem.IsUseCloudSaveKey, result);
        OnPlayerDataSaved.Invoke();
    }

    public void GetPlayerData()
    {
        GetPlayerDataExtern();
    }

    public void GetPlayerDataCallBack(string data)
    {
        Debug.Log("Recived player data is: " + data);
        string parcedJson = "";
        var jobj = JObject.Parse(data);

        if (jobj["data"].ToString() != null && jobj["data"].ToString() != string.Empty)
        {
            var json = JObject.Parse(data);
            parcedJson = GetParsedJson(json["data"].ToString());
        }
        else
        {
            SavePlayerDataCallBack("true");
        }

        OnPlayerDataRecived.Invoke(parcedJson);
    }

    public void ShowVideoAdv()
    {
        ShowVideoAdvExtern();
    }

    public void ShowVideoAdvCallBack()
    {
        OnVideoAdvRewarded.Invoke();
    }

    public void GetLanguage()
    {
        GetLanguageExtern();
    }

    public void GetCurrentLanguageExternCallBack(string language)
    {
        OnLanguageRecived.Invoke(language);
    }

    public void ShowFeedback()
    {
        ShowFeedbackExtern();
    }

    public void ShowFeedbackCallBack()
    {
        SaveSystem.SavePlayerPrefs(SaveSystem.IsFeedbackShowenKey, "true");
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private string GetParsedJson(string json)
    {
        char separator = '/';
        json.Replace(separator, ' ');
        Debug.Log("Parced jsoin is: " + json);

        return json;
    }
}