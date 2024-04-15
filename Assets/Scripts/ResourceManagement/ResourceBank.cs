using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank
{
    public event Action<ResourceType, int> ValueChanged; 
    
    private Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();
    
    public int this[ResourceType index]
    {
        get => _resources.GetValueOrDefault(index, 0);
        set
        {
            _resources[index] = value;
            ValueChanged?.Invoke(index, value);
        }
    }

    public bool ContainsResource(ResourceType type) => _resources.ContainsKey(type);
}

public enum ResourceType
{
    Eye,
    Butt,
    Stone
}
