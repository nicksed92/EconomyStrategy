using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _musicOnButton;
    [SerializeField] private Button _musicOffButton;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(OnValueChanged);
        _closeButton.onClick.AddListener(OnCloseClicked);
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
