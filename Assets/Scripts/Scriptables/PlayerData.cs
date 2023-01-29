using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public ulong Woods;
    public ulong Stones;
    public ulong GoldenNuggets;
    public ulong Fishes;
    public ulong Oils;

    public int SawMills;
    public int StoneMines;
    public int GoldMines;
    public int FishSpots;
    public int OilRigs;

    public int UnlockedRegions;

    public void Reset()
    {
        Woods = 0;
        Stones = 0;
        GoldenNuggets = 3;
        Fishes = 0;
        Oils = 0;

        SawMills = 0;
        StoneMines = 0;
        GoldMines = 0;
        FishSpots = 0;
        OilRigs = 0;

        UnlockedRegions = 1;
    }
}