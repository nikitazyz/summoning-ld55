using System;
using ResourceManagement;
using UnityEngine;

namespace Core
{
    public class Game : Singleton<Game>
    {
        [Serializable]
        public class InitialResourcesEntry
        {
            public ResourceType ResourceType;
            public int Value;
        }

        [SerializeField] private InitialResourcesEntry[] _initialResources;
        
        [SerializeField] private ResourceInfoManager _resourceInfoManager;
        private ResourceBank _resourceBank = new ResourceBank();

        public ResourceInfoManager ResourceInfoManager => _resourceInfoManager;
        public ResourceBank ResourceBank => _resourceBank;

        private void Start()
        {
            foreach (var initialResource in _initialResources)
            {
                _resourceBank[initialResource.ResourceType] = initialResource.Value;
            }
        }
    }
}