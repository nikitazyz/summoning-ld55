using UnityEngine;

namespace ResourceManagement
{
    [CreateAssetMenu]
    public class ResourceInfo : ScriptableObject
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Sprite _small;

        public ResourceType ResourceType => _resourceType;
        public Sprite Icon => _icon;
        public Sprite Small => _small;
    }
}