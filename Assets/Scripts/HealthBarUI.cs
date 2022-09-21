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
    private float _maxTextValue = 100;
    private int _minSliderValue = 0;
    private int _maxSliderValue = 1;
    private bool _referencesAreCorrect;

    private void Awake()
    {
        _referencesAreCorrect = ReferencesAreCorrect();
    }

    private void OnEnable()
    {
        if (_referencesAreCorrect)
        {
            _player.HealthChanged.AddListener(OnUpdateSlider);

            _slider.minValue = _minSliderValue;
            _slider.maxValue = _maxSliderValue;

            _rawTextValue = _textValue.text;

            _slider.value = _player.HealthPointsNormalized;
            _textValue.text = string.Format(_rawTextValue, _slider.value * _maxTextValue);
        }            
    }

    private void OnUpdateSlider()
    {
        if (_referencesAreCorrect == false)
        {
            return;
        }

        float healthPointsNormalized = _player.HealthPointsNormalized;

        _textValue.text = string.Format(_rawTextValue, healthPointsNormalized * _maxTextValue);
        _slider.value = Mathf.MoveTowards(_slider.value, healthPointsNormalized, Time.deltaTime);
    }

    private bool ReferencesAreCorrect()
    {
        bool areCorrect = true;

        if (_player == null || _slider == null || _textValue == null)
        {
            areCorrect = false;
        }

        return areCorrect;
    }
}
