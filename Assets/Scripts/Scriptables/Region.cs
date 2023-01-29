using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Region", menuName = "ScriptableObjects/Region", order = 1)]
public class Region : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _index;

    [SerializeField] private int _treesCount;
    [SerializeField] private int _stonesCount;
    [SerializeField] private int _goldenNuggetsCount;
    [SerializeField] private int _fishesCount;
    [SerializeField] private int _oilsCount;

    [SerializeField] private List<RequaredMineral> _requaredMinerals;

    public string Name => _name;
    public int Index => _index;
    public int TreesCount => _treesCount;
    public int StonesCount => _stonesCount;
    public int GoldenNuggetsCount => _goldenNuggetsCount;
    public int FishesCount => _fishesCount;
    public int OilsCount => _oilsCount;
    public List<RequaredMineral> RequaredMinerals => _requaredMinerals;
}