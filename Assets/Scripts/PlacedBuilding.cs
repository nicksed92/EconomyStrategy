using System;
using System.Collections;
using UnityEngine;

public class PlacedBuilding : MonoBehaviour
{
    [SerializeField] private Building _building;
    [SerializeField] private Canvas _buildingUICanvas;

    private SpriteRenderer _sprite;
    private SpriteRenderer _shadow;

    private void Start()
    {
        Init();
    }

    private void Init()
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
        filledSlider.Init(_building.GeneratedMinerals[0].Mineral.Color);

        Work(filledSlider, collectResourceInfo);
    }

    private void Work(FilledSlider filledSlider, CollectResourceInfo collectResourceInfo)
    {
        StartCoroutine(GenerateMineral(filledSlider, collectResourceInfo));
    }

    private IEnumerator GenerateMineral(FilledSlider filledSlider, CollectResourceInfo collectResourceInfo)
    {
        ulong minutes = _building.GeneratedMinerals[0].Minutes;
        float extractingProgress = 0f;
        float seconds = minutes * 60f;

        while (true)
        {
            extractingProgress += Time.deltaTime / seconds;
            filledSlider.SetImageFilling(extractingProgress);

            if (extractingProgress >= 1f)
            {
                collectResourceInfo.ShowInfo();
                GlobalEvents.OnMineralExtracted.Invoke(_building.GeneratedMinerals[0].Mineral);
                extractingProgress = 0f;
            }

            yield return null;
        }
    }
}