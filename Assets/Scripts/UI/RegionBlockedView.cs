using System;
using UnityEngine;
using UnityEngine.UI;

public class RegionBlockedView : MonoBehaviour
{
    [SerializeField] private GameObject _requariementPrefab;
    [SerializeField] private Transform _requariementContainer;
    [SerializeField] private Text _nameText;
    [SerializeField] private Button _unlockButton;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private PlayerdDataController _playerdDataController;

    private Region _region;

    private void Awake()
    {
        PlayerdDataController.OnMineralsChanged.AddListener(OnMineralsChanged);
    }

    public void Init(Region region)
    {
        _region = region;
        _nameText.text = $"\"{region.Name}\" is locked";

        ClearContainer();

        for (int i = 0; i < region.RequaredMinerals.Count; i++)
        {
            var clone = Instantiate(_requariementPrefab, _requariementContainer);
            var text = clone.transform.GetChild(0).GetComponent<Text>();
            var image = clone.transform.GetChild(1).GetComponent<Image>();

            text.text = region.RequaredMinerals[i].Count.ToString();
            image.sprite = region.RequaredMinerals[i].Mineral.Sprite;

            SetTextColor(text, i);
        }

        _unlockButton.interactable = IsMineralsEnough() && IsPreviousregionUnlocked();
    }

    private void OnMineralsChanged()
    {
        Init(_region);
    }

    public void OnUnlockedClicked()
    {
        int regions = _playerData.UnlockedRegions;
        _playerdDataController.UnlockRegion(_region);

        if (regions < _playerData.UnlockedRegions)
            gameObject.SetActive(false);
    }

    private bool IsPreviousregionUnlocked()
    {
        return _playerData.UnlockedRegions == _region.Index;
    }

    private void SetTextColor(Text text, int index)
    {
        text.color = _region.RequaredMinerals[index].Mineral.Color;
        var isEnough = true;

        switch (_region.RequaredMinerals[index].Mineral.Entity)
        {
            case Minerals.Wood:
                isEnough = _region.RequaredMinerals[index].Count <= _playerData.Woods;
                break;
            case Minerals.Stone:
                isEnough = _region.RequaredMinerals[index].Count <= _playerData.Stones;
                break;
            case Minerals.GoldenNugget:
                isEnough = _region.RequaredMinerals[index].Count <= _playerData.GoldenNuggets;
                break;
            case Minerals.Fish:
                isEnough = _region.RequaredMinerals[index].Count <= _playerData.Fishes;
                break;
            case Minerals.Oil:
                isEnough = _region.RequaredMinerals[index].Count <= _playerData.Oils;
                break;
        }

        if (isEnough == false)
        {
            text.color = Color.red;
        }
    }

    private void ClearContainer()
    {
        foreach (Transform requairement in _requariementContainer)
        {
            Destroy(requairement.gameObject);
        }
    }

    private bool IsMineralsEnough()
    {
        bool isEnough = true;

        for (int i = 0; i < _region.RequaredMinerals.Count; i++)
        {
            switch (_region.RequaredMinerals[i].Mineral.Entity)
            {
                case Minerals.Wood:
                    isEnough = _region.RequaredMinerals[i].Count <= _playerData.Woods;
                    break;
                case Minerals.Stone:
                    isEnough = _region.RequaredMinerals[i].Count <= _playerData.Stones;
                    break;
                case Minerals.GoldenNugget:
                    isEnough = _region.RequaredMinerals[i].Count <= _playerData.GoldenNuggets;
                    break;
                case Minerals.Fish:
                    isEnough = _region.RequaredMinerals[i].Count <= _playerData.Fishes;
                    break;
                case Minerals.Oil:
                    isEnough = _region.RequaredMinerals[i].Count <= _playerData.Oils;
                    break;
            }

            if (isEnough == false)
                break;
        }

        return isEnough;
    }
}
