using UnityEngine;

public class PlacedBuilding : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private Canvas _buildingUICanvas;

    private SpriteRenderer _sprite;
    private SpriteRenderer _shadow;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _shadow = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _sprite.sprite = _building.Sprite;
        _shadow.sprite = _building.Sprite;

        var buildingUICanvasClone = Instantiate(_buildingUICanvas, transform);
        buildingUICanvasClone.worldCamera = Camera.main;

        FilledSlider filledSlider = buildingUICanvasClone.transform.GetChild(0).GetComponent<FilledSlider>();
        CollectResourceInfo collectResourceInfo = buildingUICanvasClone.transform.GetChild(1).GetComponent<CollectResourceInfo>();

        collectResourceInfo.Init(_building);
        filledSlider.Init(_building, collectResourceInfo);
    }
}