using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _musicOnButton;
    [SerializeField] private Button _musicOffButton;
    [SerializeField] private Button _engButton;
    [SerializeField] private Button _rusButton;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
        _closeButton.onClick.AddListener(OnCloseClicked);
        _engButton.onClick.AddListener(OnEngClicked);
        _rusButton.onClick.AddListener(OnRusClicked);

        LocalizationManager.OnLocalizationLoaded.AddListener(OnLocalizationLoaded);
    }

    private void Start()
    {
        string value = SaveSystem.GetPlayerPrefs(SaveSystem.MusicVolumeKey);

        if (value != null)
        {
            float volume = float.Parse(value);
            _slider.value = volume;
            SoundManager.Instance.SetMusicVolume(volume);
        }
        else
        {
            _slider.value = SoundManager.Instance.CurrentMusicPLayingSource.volume;
        }

        value = SaveSystem.GetPlayerPrefs(SaveSystem.SoundsMuteKey);

        if (value != null)
        {
            if (value == "True")
            {
                SoundManager.Instance.MuteSounds();
                _musicOnButton.gameObject.SetActive(false);
                _musicOffButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnLocalizationLoaded()
    {
        SetFlagsButtonVisible();
    }

    private void SetFlagsButtonVisible()
    {
        _engButton.gameObject.SetActive(false);
        _rusButton.gameObject.SetActive(false);

        Debug.Log(LocalizationManager.Instance.CurrentLanguage);
        Debug.Log(Languages.DefaultLanguages.ru.ToString());

        if (LocalizationManager.Instance.CurrentLanguage == Languages.DefaultLanguages.ru.ToString())
            _rusButton.gameObject.SetActive(true);
        else
            _engButton.gameObject.SetActive(true);
    }

    private void OnEngClicked()
    {
        LocalizationManager.Instance.SetRuLanguage();
    }

    private void OnRusClicked()
    {
        LocalizationManager.Instance.SetEnLanguage();
    }

    private void OnCloseClicked()
    {
        SaveSystem.SavePlayerPrefs(SaveSystem.MusicVolumeKey, _slider.value.ToString());
        SaveSystem.SavePlayerPrefs(SaveSystem.SoundsMuteKey, SoundManager.Instance.IsSoundsMute.ToString());
    }

    private void OnValueChanged(float value)
    {
        SoundManager.Instance.SetMusicVolume(value);
    }
}
