using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building", order = 1)]
public class Building : ScriptableObject
{
    [SerializeField] private Buildings _entity;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private List<GeneratedMineral> _generatedMinerals;
    [SerializeField] private List<RequaredMineral> _requaredMinerals;

    public string Name => _entity.ToString();
    public Buildings Entity => _entity;
    public Sprite Sprite => _sprite;
    public List<GeneratedMineral> GeneratedMinerals => _generatedMinerals;
    public List<RequaredMineral> RequaredMinerals => _requaredMinerals;
}