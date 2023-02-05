using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager Instance;

    [SerializeField] private Languages.DefaultLanguages _defaultLanguage = Languages.DefaultLanguages.en;

    private Dictionary<string, string> texts = new Dictionary<string, string>();

    public static UnityEvent OnLanguageChange = new UnityEvent();
    public static UnityEvent OnLocalizationLoaded = new UnityEvent();

    public string CurrentLanguage { get; private set; }

    [DllImport("__Internal")]
    private static extern void GetCurrentLanguageExtern();

    public void SetRuLanguage()
    {
        Languages.DefaultLanguages newLanguage = Languages.DefaultLanguages.ru;

        SetLanguage(newLanguage);
    }

    public void SetEnLanguage()
    {
        Languages.DefaultLanguages newLanguage = Languages.DefaultLanguages.en;

        SetLanguage(newLanguage);
    }

    public void SetLanguage(Languages.DefaultLanguages newLanguage)
    {
        if (newLanguage.ToString() != CurrentLanguage)
        {
            CurrentLanguage = newLanguage.ToString();
            LoadLocalization();
            SaveSystem.SavePlayerPrefs(SaveSystem.IsLanguageSaveKey, CurrentLanguage);
            OnLanguageChange.Invoke();
        }
        else
        {
            throw new Exception($"Localization Error!: \"{newLanguage}\" already enabled!");
        }
    }

    public string GetText(string key)
    {
        if (!texts.ContainsKey(key))
            throw new Exception($"Localization Error!: \"{key}\" not found in keys!");

        return texts[key];
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);

        YandexSDK.OnLanguageRecived.AddListener(OnLanguageRecived);
    }

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string lang = SaveSystem.GetPlayerPrefs(SaveSystem.IsLanguageSaveKey);

        if (lang != null && lang != string.Empty)
            OnLanguageRecived(lang);
        else
            YandexSDK.Instance.GetLanguage();
#else
        OnLanguageRecived(_defaultLanguage.ToString());
#endif
    }

    private void OnLanguageRecived(string language)
    {
        if (language == null)
            CurrentLanguage = _defaultLanguage.ToString();
        else
            CurrentLanguage = language;

        Debug.Log("Current language: " + CurrentLanguage);

        LoadLocalization();
    }

    private void LoadLocalization()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("Localization/" + CurrentLanguage);

        if (textAsset == null)
            throw new Exception($"Localization Error!: \"{CurrentLanguage}.json\" not found in \"Localization/\" folder!");

        texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);

        Debug.Log("Localization loaded successfully!");

        OnLocalizationLoaded.Invoke();
    }
}