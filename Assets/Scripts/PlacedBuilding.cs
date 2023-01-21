using UnityEngine;

public class PlacedBuilding : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private RectTransform _timerCanvas;

    private FilledSlider _filledSlider;
    private SpriteRenderer _sprite;
    private SpriteRenderer _shadow;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _shadow = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _sprite.sprite = _building.Sprite;
        _shadow.sprite = _building.Sprite;

        var clone = Instantiate(_timerCanvas, transform);
        clone.GetChild(0).GetComponent<FilledSlider>().Init(_building.GeneratedMinerals[0].Minutes);
    }
}
