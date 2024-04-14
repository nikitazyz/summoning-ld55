using UnityEngine;

namespace Item
{
    public class ItemDrop : MonoBehaviour
    {
        [SerializeField] private ItemView _itemView;

        public ResourceType ResourceType
        {
            get => _itemView.ResourceType;
            set => _itemView.ResourceType = value;
        }
    }
}