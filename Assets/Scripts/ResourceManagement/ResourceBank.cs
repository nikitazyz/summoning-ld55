using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank
{
    private Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>();
    
    public int this[ResourceType index]
    {
        get => _resources.GetValueOrDefault(index, 0);
        set => _resources[index] = value;
    }

    public bool ContainsResource(ResourceType type) => _resources.ContainsKey(type);
}

public enum ResourceType
{
    Resource1,
    Resource2,
    Resource3
}
