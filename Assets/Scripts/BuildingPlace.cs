using UnityEngine;

public class BuildingPlace : MonoBehaviour
{
    [SerializeField] private Transform _treesContainer;
    [SerializeField] private Transform _stonesContainer;
    [SerializeField] private Transform _goldOresContainer;

    [SerializeField] private Transform _sawMillsContainer;
    [SerializeField] private Transform _stoneMinesContainer;
    [SerializeField] private Transform _goldMinesContainer;

    [SerializeField] private Transform _sawMill;
    [SerializeField] private Transform _stoneMine;
    [SerializeField] private Transform _goldMine;

    private int _sawMillsPlaced = 0;
    private int _stoneMinesPlaced = 0;
    private int _goldMinesPlaced = 0;

    public void Place(Buildings building)
    {
        switch (building)
        {
            case Buildings.SawMill:
                PlaceBuilding(_sawMill, _sawMillsContainer, _treesContainer, ref _sawMillsPlaced);
                break;
            case Buildings.StoneMine:
                PlaceBuilding(_stoneMine, _stoneMinesContainer, _stonesContainer, ref _stoneMinesPlaced);
                break;
            case Buildings.GoldMine:
                PlaceBuilding(_goldMine, _goldMinesContainer, _goldOresContainer, ref _goldMinesPlaced);
                break;
        }
    }

    private void PlaceBuilding(Transform building, Transform buildingsContainer, Transform resourceContainer, ref int buldingsPlaced)
    {
        Debug.LogError("buldingsPlaced " + buldingsPlaced);
        var child = resourceContainer.GetChild(buldingsPlaced);
        Transform clone = Instantiate(building, buildingsContainer);
        clone.position = child.localPosition;
        child.gameObject.SetActive(false);
        buldingsPlaced++;
    }
}
