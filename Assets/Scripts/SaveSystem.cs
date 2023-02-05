using Newtonsoft.Json;
using UnityEngine;

public class SaveSystem
{
    public const string MusicVolumeKey = "MusicVolume";
    public const string SoundsMuteKey = "SoundsMute";
    public const string IsUseCloudSaveKey = "IsUseCloudSave";
    public const string IsLanguageSaveKey = "IsLanguageSave";
    public const string IsFirstLaunchKey = "IsFirstLaunch";
    public const string IsFeedbackShowenKey = "IsFeddbackShowen";
    private const string SaveKey = "Save";

    public static void SavePlayerPrefs(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string GetPlayerPrefs(string key)
    {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetString(key);

        return null;
    }

    public static void Save<T>(T saveData)
    {
        string json = JsonConvert.SerializeObject(saveData);
        PlayerPrefs.SetString(SaveKey, json);

        if (GetPlayerPrefs(IsUseCloudSaveKey) == "true")
            YandexSDK.Instance.SavePlayerData();
    }

    public static string Load()
    {
        if (PlayerPrefs.HasKey(SaveKey))
            return PlayerPrefs.GetString(SaveKey);
        else
            return null;
    }
}