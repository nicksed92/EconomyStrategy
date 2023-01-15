using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTemplateViewHolder : MonoBehaviour
{
    [SerializeField] private BuildingTemplateView _buildingTemplateViewPrefab;
    [SerializeField] private Transform _buildingTemplatesViewContainer;
    [SerializeField] private List<Building> _buildings = new List<Building>();

    private void Start()
    {
        CreateViews();
    }

    private void CreateViews()
    {
        ClearContainer();

        for (int i = 0; i < _buildings.Count; i++)
        {
            BuildingTemplateView clone = Instantiate(_buildingTemplateViewPrefab, _buildingTemplatesViewContainer);
            clone.Init(_buildings[i]);
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
