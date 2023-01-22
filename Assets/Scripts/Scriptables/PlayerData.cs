using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public ulong Woods;
    public ulong Stones;
    public ulong GoldenNuggets;
    public int SawMills;
    public int StoneMines;
    public int GoldMines;
    public int OpenRegions;

    public void Reset()
    {
        Woods = 0;
        Stones = 0;
        GoldenNuggets = 0;

        SawMills = 0;
        StoneMines = 0;
        GoldMines = 0;

        OpenRegions = 1;
    }
}