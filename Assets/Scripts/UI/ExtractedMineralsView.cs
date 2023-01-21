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

    [SerializeField] private Image _woodImage;
    [SerializeField] private Image _stoneImage;
    [SerializeField] private Image _goldenNuggetImage;

    [SerializeField] private Text _woodsCountText;
    [SerializeField] private Text _stonesCountText;
    [SerializeField] private Text _goldenNuggetsCountText;

    private void Awake()
    {
        PlayerdDataController.OnMineralsChanged.AddListener(OnMineralsChanged);
    }

    private void Start()
    {
        _woodImage.sprite = _wood.Sprite;
        _stoneImage.sprite = _stone.Sprite;
        _goldenNuggetImage.sprite = _goldenNugget.Sprite;

        _woodsCountText.color = _wood.Color;
        _stonesCountText.color = _stone.Color;
        _goldenNuggetsCountText.color = _goldenNugget.Color;

        OnMineralsChanged();
    }

    private void OnMineralsChanged()
    {
        _woodsCountText.text = _playerData.Woods.ToString();
        _stonesCountText.text = _playerData.Stones.ToString();
        _goldenNuggetsCountText.text = _playerData.GoldenNuggets.ToString();
    }
}
