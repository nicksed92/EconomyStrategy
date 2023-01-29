using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsContentArrow : MonoBehaviour
{
    [SerializeField] private Button _upButton;
    [SerializeField] private Button _downButton;
    [SerializeField] private RectTransform _content;
    [SerializeField] private float _scrollStep = 500f;
    [SerializeField] private float _minPosY = 0;
    [SerializeField] private float _maxPosY = 2500f;

    private bool _isUpClicked = false;

    private void Awake()
    {
        _upButton.onClick.AddListener(OnUpButtonClicked);
        _downButton.onClick.AddListener(OnDownButtonClicked);

        _upButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        var anchoredPositionY = _content.anchoredPosition.y;

        if (anchoredPositionY > _minPosY)
            _upButton.gameObject.SetActive(true);
        else if (_upButton.gameObject.activeSelf)
            _upButton.gameObject.SetActive(false);

        if (anchoredPositionY < _maxPosY)
            _downButton.gameObject.SetActive(true);
        else if (_downButton.gameObject.activeSelf)
            _downButton.gameObject.SetActive(false);
    }

    private void OnUpButtonClicked()
    {
        _isUpClicked = true;

        SetContentPosition();
    }

    private void OnDownButtonClicked()
    {
        SetContentPosition();
    }

    private void SetContentPosition()
    {
        var anchoredPositionY = _content.anchoredPosition.y;

        if (_isUpClicked)
        {
            _isUpClicked = false;

            if (anchoredPositionY < _minPosY)
            {
                return;
            }

            _scrollStep = -_scrollStep;
        }
        else if (anchoredPositionY > _maxPosY)
        {
            return;
        }

        _content.anchoredPosition = new Vector2(_content.anchoredPosition.x, _content.anchoredPosition.y + _scrollStep);
        _scrollStep = Mathf.Abs(_scrollStep);
    }
}
