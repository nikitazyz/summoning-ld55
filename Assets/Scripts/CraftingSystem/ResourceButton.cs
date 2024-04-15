using System;
using UnityEngine;
using UnityEngine.UI;

namespace CraftingSystem
{
    public class ResourceButton : MonoBehaviour
    {
        public event Action<ResourceType> Clicked; 
        
        public Button Button;
        public ResourceType ResourceType;

        private void Awake()
        {
            Button.onClick.AddListener(() => Clicked?.Invoke(ResourceType));
        }
    }
}