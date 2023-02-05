using UnityEngine;
using UnityEngine.UI;

public class SetSavesVariant : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private Image _saveImage;
    [SerializeField] private Sprite _saveSuccessSrite;
    [SerializeField] private Button _saveButton;

    private void Awake()
    {
        YandexSDK.OnPlayerDataRecived.AddListener(OnPlayerDataRecived);
        YandexSDK.OnPlayerDataSaved.AddListener(OnPlayerDataSaved);
        PlayerdDataController.OnCloudSaveApplayed.AddListener(OnCloudSaveApplayed);

        if (SaveSystem.GetPlayerPrefs(SaveSystem.IsUseCloudSaveKey) == "true")
            OnCloudSaveApplayed();
    }

    private void OnPlayerDataRecived(string data)
    {
        if (data == null || data.Length == 0 || data == string.Empty)
            return;

        _content.gameObject.SetActive(true);
    }

    private void OnPlayerDataSaved()
    {
        OnCloudSaveApplayed();
    }

    private void OnCloudSaveApplayed()
    {
        _saveImage.sprite = _saveSuccessSrite;
        _saveButton.interactable = false;
    }
}
