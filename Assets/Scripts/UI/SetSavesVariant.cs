using UnityEngine;

public class SetSavesVariant : MonoBehaviour
{
    private void Awake()
    {
        YandexSDK.OnPlayerDataRecived.AddListener(OnPlayerDataRecived);
    }

    private void OnPlayerDataRecived(string data)
    {
        if (data == null || data.Length == 0 || data == string.Empty)
            return;

        transform.GetChild(0).gameObject.SetActive(true);
    }
}
