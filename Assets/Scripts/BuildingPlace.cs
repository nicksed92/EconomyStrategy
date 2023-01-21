using UnityEngine;
using UnityEngine.UI;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private Transform _treesContainer;
    [SerializeField] private Transform _stonesContainer;
    [SerializeField] private Transform _goldOresContainer;

    [SerializeField] private Transform _sawMillsContainer;
    [SerializeField] private Transform _stoneMinesContainer;
    [SerializeField] private Transform _goldMinesContainer;

    [SerializeField] private PlacedBuilding _sawMill;
    [SerializeField] private Transform _stoneMine;
    [SerializeField] private Transform _goldMine;

    [SerializeField] private int _sawMillsPlaced = 0;
    [SerializeField] private int _stoneMinesPlaced = 0;
    [SerializeField] private int _goldMinesPlaced = 0;

    public void Place(Buildings building)
    {
        switch (building)
        {
            case Buildings.SawMill:
                PlaceBuilding(_sawMill, _sawMillsContainer, _treesContainer, ref _sawMillsPlaced);
                break;
            case Buildings.StoneMine:
                //PlaceBuilding(_stoneMine, _stoneMinesContainer, _stonesContainer, ref _stoneMinesPlaced);
                break;
            case Buildings.GoldMine:
                //PlaceBuilding(_goldMine, _goldMinesContainer, _goldOresContainer, ref _goldMinesPlaced);
                break;
        }
    }

    private void PlaceBuilding(PlacedBuilding building, Transform buildingsContainer, Transform resourceContainer, ref int buldingsPlaced)
    {
        if (buldingsPlaced > resourceContainer.childCount - 1)
            return;


        var child = resourceContainer.GetChild(buldingsPlaced);

        var clone = Instantiate(building, buildingsContainer);
        clone.transform.position = child.localPosition;
        buldingsPlaced++;
        child.gameObject.SetActive(false);
    }
}
