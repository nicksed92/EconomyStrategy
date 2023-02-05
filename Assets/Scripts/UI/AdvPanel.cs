using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AdvPanel : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _advPanelButton;
    [SerializeField] private Button _button;
    [SerializeField] private float _showAdPanelDelay = 300f;
    [SerializeField] private float _showAdButtonDelay = 65f;
    [SerializeField] private float _sliderTime = 10.5f;

    private float advPanelTime;
    private float advButtonTime;

    private void Awake()
    {
        _advPanelButton.onClick.AddListener(OnShowAdvClick);
        _button.onClick.AddListener(OnShowAdvClick);
        _slider.maxValue = _sliderTime;
        _slider.value = _sliderTime;
    }

    private void Start()
    {
        StartCoroutine(ShowAdvPanel());
        StartCoroutine(ShowAdvButton());
    }

    private void OnShowAdvClick()
    {
        advPanelTime = _showAdPanelDelay;
        advButtonTime = _showAdButtonDelay;

        _button.gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);

        YandexSDK.Instance.ShowVideoAdv();
    }

    private IEnumerator ShowAdvPanel()
    {
        advPanelTime = _showAdPanelDelay;

        while (advPanelTime > 0)
        {
            advPanelTime -= Time.deltaTime;
            yield return null;
        }

        _button.gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);

        StartCoroutine(ShowAdvPanel());
        StartCoroutine(HideAdvElements());
    }

    private IEnumerator ShowAdvButton()
    {
        advButtonTime = _showAdButtonDelay;

        while (advButtonTime > 0)
        {
            advButtonTime -= Time.deltaTime;
            yield return null;
        }

        _button.gameObject.SetActive(true);
        StartCoroutine(ShowAdvButton());
    }

    private IEnumerator HideAdvElements()
    {
        float time = _sliderTime;

        while (time > 0)
        {
            time -= Time.deltaTime;
            _slider.value = time;
            yield return null;
        }

        transform.GetChild(0).gameObject.SetActive(false);
    }
}
