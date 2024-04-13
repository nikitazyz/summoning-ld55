using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public event Action<int, int> Damaged;
    public event Action<int, int> Healed;
    public event Action<int> ValueChanged;

    private int _maxValue;
    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            _value = Math.Clamp(value, 0, _maxValue);
            ValueChanged?.Invoke(_value);
        }
    }

    public Health(int maxValue)
    {
        _maxValue = maxValue;
        _value = maxValue;
    }

    public void TakeDamage(int damage)
    {
        if(damage >= _value)
        {
            Value = 0;
        }
        Value -= damage;
        Damaged?.Invoke(_value, damage);
    }

    public void Heal(int heal)
    {
        Value = Math.Min(Value + heal, _maxValue);
        Healed?.Invoke(_value, heal);
    }
}
