using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _textValue;

    private string _rawTextValue;
    private bool _allReferenceAreCorrect;
    private float _maxTextValue = 100;
    private int _minSliderValue = 0;
    private int _maxSliderValue = 1;

    private void OnEnable()
    {
        if (_player != null && _slider != null && _textValue != null)
        {
            _allReferenceAreCorrect = true;
            _slider.minValue = _minSliderValue;
            _slider.maxValue = _maxSliderValue;

            _rawTextValue = _textValue.text;

            _slider.value = _player.HealthPointsNormalized;
            _textValue.text = string.Format(_rawTextValue, _slider.value * _maxTextValue);
        }            
    }

    private void Update()
    {
        UpdateSlider();
    }

    private void UpdateSlider()
    {
        float healthPointsNormalized = _player.HealthPointsNormalized;

        if (_allReferenceAreCorrect == false || _slider.value == healthPointsNormalized)
        {
            return;
        }

        _textValue.text = string.Format(_rawTextValue, healthPointsNormalized * _maxTextValue);
        _slider.value = Mathf.MoveTowards(_slider.value, healthPointsNormalized, Time.deltaTime);
    }
}
