using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action<GameObject, int> ValueChanged;

    private Dictionary<GameObject, int> _inventory = new Dictionary<GameObject, int>();

    public void AddToInventory(GameObject element)
    {
        if (_inventory.ContainsKey(element))
        {
            _inventory[element]++;
        }
        else
        {
            _inventory[element] = 0;
        }
        ValueChanged?.Invoke(element, _inventory[element]);
    }

    public bool CanUse(GameObject element) => _inventory.ContainsKey(element) && _inventory[element] > 0;
    public int GetCount(GameObject element) => _inventory.GetValueOrDefault(element, 0);
    public void Use(GameObject element)
    {
        if (!_inventory.ContainsKey(element) || _inventory[element] <= 0)
        {
            return;
        }

        _inventory[element]--;
        ValueChanged?.Invoke(element, _inventory[element]);
    }
}
