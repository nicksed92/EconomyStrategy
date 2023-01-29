using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtractedMineralsView : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    [SerializeField] private Mineral _wood;
    [SerializeField] private Mineral _stone;
    [SerializeField] private Mineral _goldenNugget;
    [SerializeField] private Mineral _fish;
    [SerializeField] private Mineral _oil;

    [SerializeField] private Image _woodImage;
    [SerializeField] private Image _stoneImage;
    [SerializeField] private Image _goldenNuggetImage;
    [SerializeField] private Image _fishImage;
    [SerializeField] private Image _oilImage;

    [SerializeField] private Text _woodsCountText;
    [SerializeField] private Text _stonesCountText;
    [SerializeField] private Text _goldenNuggetsCountText;
    [SerializeField] private Text _fishesCountText;
    [SerializeField] private Text _oilsCountText;

    private void Awake()
    {
        PlayerdDataController.OnMineralsChanged.AddListener(OnMineralsChanged);
        PlayerdDataController.OnDataLoaded.AddListener(OnMineralsChanged);
    }

    private void Start()
    {
        _woodImage.sprite = _wood.Sprite;
        _stoneImage.sprite = _stone.Sprite;
        _goldenNuggetImage.sprite = _goldenNugget.Sprite;
        _fishImage.sprite = _fish.Sprite;
        _oilImage.sprite = _oil.Sprite;

        _woodsCountText.color = _wood.Color;
        _stonesCountText.color = _stone.Color;
        _goldenNuggetsCountText.color = _goldenNugget.Color;
        _fishesCountText.color = _fish.Color;
        _oilsCountText.color = _oil.Color;

        OnMineralsChanged();
    }

    private void OnMineralsChanged()
    {
        _woodsCountText.text = _playerData.Woods.ToString();
        _stonesCountText.text = _playerData.Stones.ToString();
        _goldenNuggetsCountText.text = _playerData.GoldenNuggets.ToString();
        _fishesCountText.text = _playerData.Fishes.ToString();
        _oilsCountText.text = _playerData.Oils.ToString();
    }
}
