using UnityEngine;
using System;

[Serializable]
public class RequaredMineral
{
    [SerializeField] private Mineral _mineral;
    [SerializeField] private ulong _count;

    public ulong Count => _count;
    public Mineral Mineral => _mineral;
}
