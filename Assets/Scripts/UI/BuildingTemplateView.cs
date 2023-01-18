using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTemplateView : MonoBehaviour
{
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

    public void Init(Building building, BuildingPlace buildingPlace)
    {
        _nameText.text = building.Name;
        _backGround.color = building.Color;
        _buildingSprite.sprite = building.Sprite;
        _buildingShadow.sprite = building.Sprite;

        SetRequaredMineralsView(building.RequaredMinerals);
        SetGeneratedMineralsView(building.GeneratedMinerals);

        _buildButton.onClick.AddListener(delegate { OnBuildButtonClicked(building.Entity, buildingPlace); });
    }

    private void OnBuildButtonClicked(Buildings entity, BuildingPlace buildingPlace)
    {
        buildingPlace.Place(entity);
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