using UnityEngine;
using UnityEngine.Events;

public class PlayerdDataController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    public static UnityEvent OnDataLoaded = new UnityEvent();
    public static UnityEvent OnMineralsChanged = new UnityEvent();

    private void Awake()
    {
        GlobalEvents.OnMineralExtracted.AddListener(OnMineralExtracted);
    }

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        _playerData.Reset();

        string json = SaveSystem.Load();
        JsonUtility.FromJsonOverwrite(json, _playerData);

        OnDataLoaded.Invoke();
    }

    private void OnMineralExtracted(Mineral mineral)
    {
        switch (mineral.Entity)
        {
            case Minerals.Wood:
                _playerData.Wood++;
                break;
            case Minerals.Stone:
                _playerData.Stone++;
                break;
            case Minerals.GoldenNugget:
                _playerData.GoldenNugget++;
                break;
            case Minerals.Fish:
                _playerData.Fish++;
                break;
            case Minerals.Oil:
                _playerData.Oil++;
                break;
        }

        OnMineralsChanged.Invoke();

        SaveSystem.Save(_playerData);
    }
}