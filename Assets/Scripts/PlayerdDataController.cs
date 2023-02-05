using UnityEngine;
using UnityEngine.Events;

public class PlayerdDataController : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private ulong _goldenNuggetsRewardedCount = 3;

    private string _saveCloudJson;

    public static UnityEvent OnDataLoaded = new UnityEvent();
    public static UnityEvent OnCloudSaveApplayed = new UnityEvent();
    public static UnityEvent OnMineralsChanged = new UnityEvent();

    public void BuyBuilding(Building building)
    {
        for (int i = 0; i < building.RequaredMinerals.Count; i++)
        {
            ulong requaredMineralsCount = building.RequaredMinerals[i].Count;

            switch (building.RequaredMinerals[i].Mineral.Entity)
            {
                case Minerals.Wood:
                    if (_playerData.Woods < requaredMineralsCount)
                        return;

                    _playerData.Woods -= requaredMineralsCount;
                    break;
                case Minerals.Stone:
                    if (_playerData.Stones < requaredMineralsCount)
                        return;

                    _playerData.Stones -= requaredMineralsCount;
                    break;
                case Minerals.GoldenNugget:
                    if (_playerData.GoldenNuggets < requaredMineralsCount)
                        return;

                    _playerData.GoldenNuggets -= requaredMineralsCount;
                    break;
                case Minerals.Fish:
                    if (_playerData.Fishes < requaredMineralsCount)
                        return;

                    _playerData.Fishes -= requaredMineralsCount;
                    break;
                case Minerals.Oil:
                    if (_playerData.Oils < requaredMineralsCount)
                        return;

                    _playerData.Oils -= requaredMineralsCount;
                    break;
            }
        }

        OnMineralsChanged.Invoke();
    }

    public void UnlockRegion(Region region)
    {
        for (int i = 0; i < region.RequaredMinerals.Count; i++)
        {
            ulong requaredMineralsCount = region.RequaredMinerals[i].Count;

            switch (region.RequaredMinerals[i].Mineral.Entity)
            {
                case Minerals.Wood:
                    if (_playerData.Woods < requaredMineralsCount)
                        return;

                    _playerData.Woods -= requaredMineralsCount;
                    break;
                case Minerals.Stone:
                    if (_playerData.Stones < requaredMineralsCount)
                        return;

                    _playerData.Stones -= requaredMineralsCount;
                    break;
                case Minerals.GoldenNugget:
                    if (_playerData.GoldenNuggets < requaredMineralsCount)
                        return;

                    _playerData.GoldenNuggets -= requaredMineralsCount;
                    break;
                case Minerals.Fish:
                    if (_playerData.Fishes < requaredMineralsCount)
                        return;

                    _playerData.Fishes -= requaredMineralsCount;
                    break;
                case Minerals.Oil:
                    if (_playerData.Oils < requaredMineralsCount)
                        return;

                    _playerData.Oils -= requaredMineralsCount;
                    break;
            }
        }

        _playerData.UnlockedRegions++;
        OnMineralsChanged.Invoke();
    }

    public void SetCloudSaveToMain()
    {
        SaveSystem.SavePlayerPrefs(SaveSystem.IsUseCloudSaveKey, "true");

        _playerData.Reset();
        JsonUtility.FromJsonOverwrite(_saveCloudJson, _playerData);
        SaveSystem.Save(_playerData);
        OnDataLoaded.Invoke();
        OnCloudSaveApplayed.Invoke();
    }

    private void Awake()
    {
        GlobalEvents.OnMineralExtracted.AddListener(OnMineralExtracted);
        YandexSDK.OnPlayerDataRecived.AddListener(OnPlayerDataRecived);
        YandexSDK.OnVideoAdvRewarded.AddListener(OnVideoAdvRewarded);
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

    private void OnPlayerDataRecived(string json)
    {
        _saveCloudJson = json;
    }

    private void OnVideoAdvRewarded()
    {
        _playerData.GoldenNuggets += _goldenNuggetsRewardedCount;

        SaveSystem.Save(_playerData);
    }

    private void OnMineralExtracted(Mineral mineral)
    {
        SoundManager.Instance.PlaySound("Collect");

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
            case Minerals.Fish:
                _playerData.Fishes++;
                break;
            case Minerals.Oil:
                _playerData.Oils++;
                break;
        }

        OnMineralsChanged.Invoke();

        SaveSystem.Save(_playerData);
    }
}