using System;
using UnityEngine;
using UnityEngine.UI;

public class FirstLaunchPanel : MonoBehaviour
{
    [SerializeField] private Transform _clickPanel;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);

        if (SaveSystem.GetPlayerPrefs(SaveSystem.IsFirstLaunchKey) != null)
        {
            gameObject.SetActive(false);
            _clickPanel.gameObject.SetActive(true);

            if (SaveSystem.GetPlayerPrefs(SaveSystem.IsFeedbackShowenKey) == null)
                YandexSDK.Instance.ShowFeedback();
        }
    }

    private void OnClick()
    {
        SaveSystem.SavePlayerPrefs(SaveSystem.IsFirstLaunchKey, "true");
        gameObject.SetActive(false);
    }
}
