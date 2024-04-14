using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ResourceManagement
{
    [CreateAssetMenu]
    public class ResourceInfoManager : ScriptableObject
    {
        [SerializeField] private List<ResourceInfo> _resourceInfos = new List<ResourceInfo>();

        private Dictionary<ResourceType, ResourceInfo> _resourceInfosDictionary;
        
        private void Awake()
        {
            _resourceInfosDictionary = new Dictionary<ResourceType, ResourceInfo>();
            foreach (var resourceInfo in _resourceInfos)
            {
                _resourceInfosDictionary[resourceInfo.ResourceType] = resourceInfo;
            }
        }

        public ResourceInfo GetInfo(ResourceType type)
        {
            if (_resourceInfosDictionary == null)
            {
                return _resourceInfos.First(info => info.ResourceType == type);
            }

            return _resourceInfosDictionary.GetValueOrDefault(type, null);
        }
    }
}