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
        PlayerdDataController.OnWoodsCountChanged.AddListener(OnWoodsContChange);
        PlayerdDataController.OnStonesCountChanged.AddListener(OnStonesContChange);
        PlayerdDataController.OnGoldenNuggetsCountChanged.AddListener(OnGoldenNuggetsContChange);
    }

    private void Start()
    {
        _woodImage.sprite = _wood.Sprite;
        _stoneImage.sprite = _stone.Sprite;
        _goldenNuggetImage.sprite = _goldenNugget.Sprite;

        OnWoodsContChange(_playerData.Woods);
        OnStonesContChange(_playerData.Stones);
        OnGoldenNuggetsContChange(_playerData.GoldenNuggets);
    }

    private void OnWoodsContChange(ulong count)
    {
        _woodsCountText.text = count.ToString();
    }

    private void OnStonesContChange(ulong count)
    {
        _stonesCountText.text = count.ToString();
    }

    private void OnGoldenNuggetsContChange(ulong count)
    {
        _goldenNuggetsCountText.text = count.ToString();
    }
}
