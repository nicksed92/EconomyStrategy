using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private List<Vector3> _mapPoints = new List<Vector3>();
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Transform _blockPanel;
    [SerializeField] private RegionBlockedView _regionBlockedView;
    [SerializeField] private List<Region> _regions = new List<Region>();

    private Vector3 _startPosition;
    private int _currentPositionIndex;
    private Camera _camera;

    public void SetNextPosition()
    {
        if (_currentPositionIndex > _mapPoints.Count - 1)
            return;

        SetPosition(_mapPoints[++_currentPositionIndex]);
    }

    public void SetPreviosPosition()
    {
        if (_currentPositionIndex == 0)
            return;

        SetPosition(_mapPoints[--_currentPositionIndex]);
    }

    private void Awake()
    {
        _leftButton.onClick.AddListener(SetPreviosPosition);
        _rightButton.onClick.AddListener(SetNextPosition);
    }

    private void Start()
    {
        _camera = GetComponent<Camera>();

        _startPosition = _mapPoints[0];
        _currentPositionIndex = _mapPoints.IndexOf(_startPosition);

        SetPosition(_startPosition);
    }

    private void SetPosition(Vector3 position)
    {
        _camera.transform.position = position;

        if (_currentPositionIndex == _mapPoints.Count - 1)
        {
            _rightButton.gameObject.SetActive(false);
        }
        else
        {
            _rightButton.gameObject.SetActive(true);
        }

        if (_currentPositionIndex == 0)
        {
            _leftButton.gameObject.SetActive(false);
        }
        else
        {
            _leftButton.gameObject.SetActive(true);
        }

        if (_playerData.UnlockedRegions < _currentPositionIndex + 1)
        {
            _regionBlockedView.Init(_regions[_currentPositionIndex]);
            _blockPanel.gameObject.SetActive(true);
        }
        else
        {
            _blockPanel.gameObject.SetActive(false);
        }
    }
}
