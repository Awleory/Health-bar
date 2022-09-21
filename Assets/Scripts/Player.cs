using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoints;

    public float HealthPointsNormalized
    {
        get
        {
            if (_maxHealthPoints > 0)
            {
                int decimalPlaces = 2;
                return (float)Math.Round((decimal)(_healthPoints / _maxHealthPoints), decimalPlaces);
            }
            else
            {
                return 0;
            }
        }
    }

    private float _healthPoints;

    private void OnEnable()
    {
        Init();
    }

    public void Init()
    {
        _healthPoints = _maxHealthPoints;
    }

    public void TakeDamage(float damageValue)
    {
        if (damageValue < 0)
        {
            return;
        }

        _healthPoints -= damageValue;
        if (_healthPoints < 0)
        {
            _healthPoints = 0;
        }
    }

    public void Heal(float healValue)
    {
        if (healValue < 0)
        {
            return;
        }

        _healthPoints += healValue;
        if (_healthPoints > _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }
    }
}
