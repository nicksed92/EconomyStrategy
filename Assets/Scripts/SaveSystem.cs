using Newtonsoft.Json;
using UnityEngine;

public class SaveSystem
{
    private const string SaveKey = "Save";

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