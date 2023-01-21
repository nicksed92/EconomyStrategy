using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [SerializeField] private ulong _woods;
    [SerializeField] private ulong _stones;
    [SerializeField] private ulong _goldenNuggets;

    [SerializeField] private int _sawMills;
    [SerializeField] private int _stoneMines;
    [SerializeField] private int _goldMines;

    public ulong Woods { get { return _woods; } set { _woods = value >= 0 ? value : _woods; } }
    public ulong Stones { get { return _stones; } set { _stones = value >= 0 ? value : _stones; } }
    public ulong GoldenNuggets { get { return _goldenNuggets; } set { _goldenNuggets = value >= 0 ? value : _goldenNuggets; } }
    public int SawMills { get { return _sawMills; } set { _sawMills = value >= 0 ? value : _sawMills; } }
    public int StoneMines { get { return _stoneMines; } set { _stoneMines = value >= 0 ? value : _stoneMines; } }
    public int GoldMines { get { return _goldMines; } set { _goldMines = value >= 0 ? value : _goldMines; } }

    public void Reset()
    {
        _woods = 0;
        _stones = 0;
        _goldenNuggets = 0;

        _sawMills = 0;
        _stoneMines = 0;
        _goldMines = 0;
    }
}
