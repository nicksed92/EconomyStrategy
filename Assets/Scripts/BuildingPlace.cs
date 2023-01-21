using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private Transform _treesContainer;
    [SerializeField] private Transform _stonesContainer;
    [SerializeField] private Transform _goldOresContainer;

    [SerializeField] private Transform _sawMillsContainer;
    [SerializeField] private Transform _stoneMinesContainer;
    [SerializeField] private Transform _goldMinesContainer;

    [SerializeField] private PlacedBuilding _sawMill;
    [SerializeField] private PlacedBuilding _stoneMine;
    [SerializeField] private PlacedBuilding _goldMine;

    [SerializeField] private PlayerData _playerData;

    public void Place(Buildings building)
    {
        switch (building)
        {
            case Buildings.SawMill:
                _playerData.SawMills = PlaceBuilding(_sawMill, _sawMillsContainer, _treesContainer, _playerData.SawMills);
                break;
            case Buildings.StoneMine:
                _playerData.StoneMines = PlaceBuilding(_stoneMine, _stoneMinesContainer, _stonesContainer, _playerData.StoneMines);
                break;
            case Buildings.GoldMine:
                _playerData.GoldMines = PlaceBuilding(_goldMine, _goldMinesContainer, _goldOresContainer, _playerData.GoldMines);
                break;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _playerData.SawMills; i++)
        {
            PlaceBuyedBuildings(_sawMill, _sawMillsContainer, _treesContainer, i);
        }

        for (int i = 0; i < _playerData.StoneMines; i++)
        {
            PlaceBuyedBuildings(_stoneMine, _stoneMinesContainer, _stonesContainer, i);
        }

        for (int i = 0; i < _playerData.GoldMines; i++)
        {
            PlaceBuyedBuildings(_goldMine, _goldMinesContainer, _goldOresContainer, i);
        }
    }

    private int PlaceBuilding(PlacedBuilding building, Transform buildingsContainer, Transform resourceContainer, int buldingsPlaced)
    {
        if (buldingsPlaced > resourceContainer.childCount - 1)
            return buldingsPlaced;

        var child = resourceContainer.GetChild(buldingsPlaced);

        var clone = Instantiate(building, buildingsContainer);
        clone.transform.position = child.localPosition;
        child.gameObject.SetActive(false);
        return ++buldingsPlaced;
    }

    private void PlaceBuyedBuildings(PlacedBuilding building, Transform buildingsContainer, Transform resourceContainer, int buldingsPlaced)
    {
        var child = resourceContainer.GetChild(buldingsPlaced);

        var clone = Instantiate(building, buildingsContainer);
        clone.transform.position = child.localPosition;
        child.gameObject.SetActive(false);
    }
}
