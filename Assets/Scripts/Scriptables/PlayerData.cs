using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public ulong Wood;
    public ulong Stone;
    public ulong GoldenNugget;
    public ulong Fish;
    public ulong Oil;

    public int SawMills;
    public int StoneMines;
    public int GoldMines;
    public int FishSpots;
    public int OilRigs;

    public int OpenRegions;

    public void Reset()
    {
        Wood = 0;
        Stone = 0;
        GoldenNugget = 3;
        Fish = 0;
        Oil = 0;

        SawMills = 0;
        StoneMines = 0;
        GoldMines = 0;
        FishSpots = 0;
        OilRigs = 0;

        OpenRegions = 1;
    }
}