using System.Collections.Generic;
using UnityEngine;

public class BuildingTemplateViewHolder : MonoBehaviour
{
    [SerializeField] private BuildingTemplateView _buildingTemplateViewPrefab;
    [SerializeField] private Transform _buildingTemplatesViewContainer;
    [SerializeField] private List<Building> _buildings = new List<Building>();
    [SerializeField] private BuildingPlace _buildingPlace;
    [SerializeField] private List<BuildingTemplateView> _buildingTemplateViews = new List<BuildingTemplateView>();

    private void Awake()
    {
        LocalizationManager.OnLocalizationLoaded.AddListener(CreateViews);
        PlayerdDataController.OnMineralsChanged.AddListener(OnMineralsChanged);
        PlayerdDataController.OnDataLoaded.AddListener(CreateViews);
    }

    private void CreateViews()
    {
        ClearContainer();

        for (int i = 0; i < _buildings.Count; i++)
        {
            var clone = Instantiate(_buildingTemplateViewPrefab, _buildingTemplatesViewContainer);
            clone.Init(_buildings[i], _buildingPlace);
            _buildingTemplateViews.Add(clone);
        }
    }

    private void OnMineralsChanged()
    {
        for (int i = 0; i < _buildingTemplateViews.Count; i++)
        {
            _buildingTemplateViews[i].SetButtonInteractable();
        }
    }

    private void ClearContainer()
    {
        foreach (Transform child in _buildingTemplatesViewContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
