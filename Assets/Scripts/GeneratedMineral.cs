using UnityEngine;
using System;

[Serializable]
public class GeneratedMineral
{
    [SerializeField] private Mineral _mineral;
    [SerializeField] private ulong _count;
    [SerializeField] private ulong _minutes;

    public Mineral Mineral => _mineral;
    public ulong Count => _count;
    public ulong Minutes => _minutes;
}
