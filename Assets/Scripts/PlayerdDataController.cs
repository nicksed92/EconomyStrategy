using UnityEngine;
using UnityEngine.Events;

public class PlayerdDataController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public static UnityEvent OnMineralsChanged = new UnityEvent();

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
                break;
            case Minerals.Stone:
                _playerData.Stones++;
                break;
            case Minerals.GoldenNugget:
                _playerData.GoldenNuggets++;
                break;
        }

        OnMineralsChanged.Invoke();
    }
}
