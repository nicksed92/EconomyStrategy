using Newtonsoft.Json;
using UnityEngine;

public class SaveSystem
{
    public const string PlayerDataIsSaveKey = "PlayerData";
    public const string MusicVolumeKey = "MusicVolume";
    public const string SoundsMuteKey = "SoundsMute";
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
    }

    public static string Load()
    {
        if (PlayerPrefs.HasKey(SaveKey))
            return PlayerPrefs.GetString(SaveKey);
        else
            return null;
    }
}