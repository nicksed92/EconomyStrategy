using System.Collections.Generic;
using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private PlayerdDataController _playerdDataController;
    [SerializeField] private List<Region> _regions;

    [Header("Здания")]
    [SerializeField] private PlacedBuilding _sawMill;
    [SerializeField] private PlacedBuilding _stoneMine;
    [SerializeField] private PlacedBuilding _goldMine;
    [SerializeField] private PlacedBuilding _fishSpot;
    [SerializeField] private PlacedBuilding _oilRig;

    [Header("Русурсы")]
    [SerializeField] private Transform _treesContainer;
    [SerializeField] private Transform _stonesContainer;
    [SerializeField] private Transform _goldOresContainer;
    [SerializeField] private Transform _fishesContainer;
    [SerializeField] private Transform _oilsContainer;

    [Header("Постройки")]
    [SerializeField] private Transform _sawMillsContainer;
    [SerializeField] private Transform _stoneMinesContainer;
    [SerializeField] private Transform _goldMinesContainer;
    [SerializeField] private Transform _fishSpotsContainer;
    [SerializeField] private Transform _oilRigsContainer;

    public void Place(Buildings building)
    {
        switch (building)
        {
            case Buildings.SawMill:
                PlaceBuilding(_sawMill, Buildings.SawMill, _treesContainer, _sawMillsContainer, ref _playerData.SawMills);
                break;
            case Buildings.StoneMine:
                PlaceBuilding(_stoneMine, Buildings.StoneMine, _stonesContainer, _stoneMinesContainer, ref _playerData.StoneMines);
                break;
            case Buildings.GoldMine:
                PlaceBuilding(_goldMine, Buildings.GoldMine, _goldOresContainer, _goldMinesContainer, ref _playerData.GoldMines);
                break;
            case Buildings.FishSpot:
                PlaceBuilding(_fishSpot, Buildings.FishSpot, _fishesContainer, _fishSpotsContainer, ref _playerData.FishSpots);
                break;
            case Buildings.OilRig:
                PlaceBuilding(_oilRig, Buildings.OilRig, _oilsContainer, _oilRigsContainer, ref _playerData.OilRigs);
                break;
        }

        SaveSystem.Save(_playerData);
    }

    public int GetRegionResourcesCount(int regionNumber, Buildings entity)
    {
        switch (entity)
        {
            case Buildings.SawMill:
                return _regions[regionNumber].TreesCount;
            case Buildings.StoneMine:
                return _regions[regionNumber].StonesCount;
            case Buildings.GoldMine:
                return _regions[regionNumber].GoldenNuggetsCount;
            case Buildings.FishSpot:
                return _regions[regionNumber].FishesCount;
            case Buildings.OilRig:
                return _regions[regionNumber].OilsCount;
            default: return 0;
        }
    }

    private void Awake()
    {
        PlayerdDataController.OnDataLoaded.AddListener(OnDataLoaded);
    }

    private void OnDataLoaded()
    {
        for (int i = 0; i < _playerData.SawMills; i++)
        {
            PlaceBuyedBuildings(_sawMill, _treesContainer, _sawMillsContainer, i);
        }

        for (int i = 0; i < _playerData.StoneMines; i++)
        {
            PlaceBuyedBuildings(_stoneMine, _stonesContainer, _stoneMinesContainer, i);
        }

        for (int i = 0; i < _playerData.GoldMines; i++)
        {
            PlaceBuyedBuildings(_goldMine, _goldOresContainer, _goldMinesContainer, i);
        }

        for (int i = 0; i < _playerData.FishSpots; i++)
        {
            PlaceBuyedBuildings(_fishSpot, _fishesContainer, _fishSpotsContainer, i);
        }

        for (int i = 0; i < _playerData.OilRigs; i++)
        {
            PlaceBuyedBuildings(_oilRig, _oilsContainer, _oilRigsContainer, i);
        }
    }

    private void PlaceBuilding(PlacedBuilding building, Buildings entity, Transform resourcesContainer, Transform buildingsContainer, ref int buildingsCount)
    {
        var availablePlacingPoints = 0;

        for (int i = 0; i < _playerData.UnlockedRegions; i++)
        {
            availablePlacingPoints += GetRegionResourcesCount(i, entity);
        }

        if (resourcesContainer.childCount - 1 < buildingsCount || buildingsCount == availablePlacingPoints)
            return;

        var clone = Instantiate(building, buildingsContainer);
        var position = resourcesContainer.GetChild(buildingsCount).position;
        clone.transform.position = position;

        buildingsCount++;

        _playerdDataController.BuyBuilding(building.Building);
        SoundManager.Instance.PlaySound("Put");
    }

    private void PlaceBuyedBuildings(PlacedBuilding building, Transform resourceContainer, Transform buildingsContainer, int buldingsPlaced)
    {
        var child = resourceContainer.GetChild(buldingsPlaced);
        var clone = Instantiate(building, buildingsContainer);
        clone.transform.position = child.position;
        child.gameObject.SetActive(false);
    }
}