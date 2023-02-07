using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FastLocalizationUI : MonoBehaviour
{
    [SerializeField] private string _key;

    private Text _text;

    private void Awake()
    {
        LocalizationManager.OnLanguageChanged.AddListener(OnLanguageChangeHandler);
    }

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = LocalizationManager.Instance.GetText(_key);
    }

    private void OnLanguageChangeHandler()
    {
        if (_text == null || _key == null)
            return;

        _text.text = LocalizationManager.Instance.GetText(_key);
    }
}