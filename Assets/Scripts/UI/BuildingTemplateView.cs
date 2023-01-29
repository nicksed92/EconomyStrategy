using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTemplateView : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _priceText;
    [SerializeField] private Text _extractionText;
    [SerializeField] private Text _priceCountText;
    [SerializeField] private Image _backGround;
    [SerializeField] private Image _buildingSprite;
    [SerializeField] private Image _buildingShadow;
    [SerializeField] private Image _requaredMineralImage;
    [SerializeField] private Image _generatedMineralImage;
    [SerializeField] private Button _buildButton;

    private Building _building;
    private BuildingPlace _buildingPlace;

    public void Init(Building building, BuildingPlace buildingPlace)
    {
        _building = building;
        _buildingPlace = buildingPlace;

        _nameText.text = building.Name;
        _backGround.color = building.GeneratedMinerals[0].Mineral.Color;
        _buildingSprite.sprite = building.Sprite;
        _buildingShadow.sprite = building.Sprite;

        SetRequaredMineralsView(building.RequaredMinerals);
        SetGeneratedMineralsView(building.GeneratedMinerals);

        _buildButton.onClick.AddListener(delegate { OnBuildButtonClicked(building, buildingPlace); });

        SetButtonInteractable();
    }

    private void Awake()
    {
        GlobalEvents.OnMineralExtracted.AddListener(OnMineralExtracted);
    }

    private void OnMineralExtracted(Mineral mineral)
    {
        SetButtonInteractable();
    }

    private void SetButtonInteractable()
    {
        var availablePlacingPoints = 0;

        for (int i = 0; i < _playerData.UnlockedRegions; i++)
        {
            availablePlacingPoints += _buildingPlace.GetRegionResourcesCount(i, _building.Entity);
        }

        int buildingsCount = 0;

        switch (_building.Entity)
        {
            case Buildings.SawMill:
                buildingsCount = _playerData.SawMills;
                break;
            case Buildings.StoneMine:
                buildingsCount = _playerData.StoneMines;
                break;
            case Buildings.GoldMine:
                buildingsCount = _playerData.GoldMines;
                break;
            case Buildings.FishSpot:
                buildingsCount = _playerData.FishSpots;
                break;
            case Buildings.OilRig:
                buildingsCount = _playerData.OilRigs;
                break;
        }

        var isMineralsEnough = true;

        for (int i = 0; i < _building.RequaredMinerals.Count; i++)
        {
            ulong playerMineralsCount = 0;
            ulong requaredMineralsCount = _building.RequaredMinerals[i].Count;

            switch (_building.RequaredMinerals[i].Mineral.Entity)
            {
                case Minerals.Wood:
                    playerMineralsCount = _playerData.Woods;
                    break;
                case Minerals.Stone:
                    playerMineralsCount = _playerData.Stones;
                    break;
                case Minerals.GoldenNugget:
                    playerMineralsCount = _playerData.GoldenNuggets;
                    break;
                case Minerals.Fish:
                    playerMineralsCount = _playerData.Fishes;
                    break;
                case Minerals.Oil:
                    playerMineralsCount = _playerData.Oils;
                    break;
            }

            if (playerMineralsCount < requaredMineralsCount)
            {
                isMineralsEnough = false;
                break;
            }
        }

        if (buildingsCount == availablePlacingPoints || isMineralsEnough == false)
            _buildButton.interactable = false;
        else
            _buildButton.interactable = true;
    }

    private void OnBuildButtonClicked(Building building, BuildingPlace buildingPlace)
    {
        buildingPlace.Place(building.Entity);

        SetButtonInteractable();
    }

    private void SetRequaredMineralsView(List<RequaredMineral> requaredMinerals)
    {
        Text tempText = _priceCountText;
        Image tempImage = _requaredMineralImage;

        for (int i = 0; i < requaredMinerals.Count; i++)
        {
            if (i > 0)
            {
                Text textClone = Instantiate(_priceCountText, _priceCountText.transform.parent);
                tempText = textClone;
                Image imageClone = Instantiate(_requaredMineralImage, _requaredMineralImage.transform.parent);
                tempImage = imageClone;
            }

            tempText.text = requaredMinerals[i].Count.ToString();
            tempImage.sprite = requaredMinerals[i].Mineral.Sprite;
        }
    }

    private void SetGeneratedMineralsView(List<GeneratedMineral> generatedMinerals)
    {
        Image tempImage = _generatedMineralImage;

        for (int i = 0; i < generatedMinerals.Count; i++)
        {
            if (i > 0)
            {
                Image imageClone = Instantiate(_generatedMineralImage, _generatedMineralImage.transform.parent);
                tempImage = imageClone;
            }

            tempImage.sprite = generatedMinerals[i].Mineral.Sprite;
        }
    }
}