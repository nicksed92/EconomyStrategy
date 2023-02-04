using Newtonsoft.Json;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance { get; private set; }

    [SerializeField] private PlayerData _playerData;

    public static UnityEvent<string> OnPlayerDataRecived = new UnityEvent<string>();

    [DllImport("__Internal")]
    private static extern void SavePlayerDataExtern(string data);

    [DllImport("__Internal")]
    private static extern void GetPlayerDataExtern();


    public void SavePlayerDataCallBack(string result)
    {
        SaveSystem.SavePlayerPrefs(SaveSystem.PlayerDataIsSaveKey, result);
    }

    public void GetPlayerData()
    {
        GetPlayerDataExtern();
    }

    public void GetPlayerDataCallBack(string data)
    {
        Debug.Log("Recived player data is: " + data);
        OnPlayerDataRecived.Invoke(data);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void SavePlayerData()
    {
        string data = JsonConvert.SerializeObject(_playerData);
        SavePlayerDataExtern(data);
    }
}