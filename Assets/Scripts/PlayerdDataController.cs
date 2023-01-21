using UnityEngine;
using UnityEngine.Events;

public class PlayerdDataController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public static UnityEvent<ulong> OnWoodsCountChanged = new UnityEvent<ulong>();
    public static UnityEvent<ulong> OnStonesCountChanged = new UnityEvent<ulong>();
    public static UnityEvent<ulong> OnGoldenNuggetsCountChanged = new UnityEvent<ulong>();

    private void Awake()
    {
        GlobalEvents.OnMineralExtracted.AddListener(OnMineralExtracted);
    }

    private void Start()
    {
        //_playerData.Reset();
    }

    private void OnMineralExtracted(Mineral mineral)
    {
        switch (mineral.Entity)
        {
            case Minerals.Wood:
                _playerData.Woods++;
                OnWoodsCountChanged.Invoke(_playerData.Woods);
                break;
            case Minerals.Stone:
                _playerData.Stones++;
                OnStonesCountChanged.Invoke(_playerData.Stones);
                break;
            case Minerals.GoldenNugget:
                _playerData.GoldenNuggets++;
                OnGoldenNuggetsCountChanged.Invoke(_playerData.GoldenNuggets);
                break;
        }
    }
}
