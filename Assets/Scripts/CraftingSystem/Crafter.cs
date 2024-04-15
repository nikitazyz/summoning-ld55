using Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CraftingSystem
{
    public class Crafter : MonoBehaviour
    {
        [SerializeField] private CraftReceipts _receipts;
        [SerializeField] private ResourceButton[] _resourceButtons;
        [SerializeField] private Button _clear;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Image _cell1;
        [SerializeField] private Image _cell2;
        [SerializeField] private Image _cell3;

        private ResourceCell _resourceCell1;
        private ResourceCell _resourceCell2;
        private ResourceCell _resourceCell3;

        private void Awake()
        {
            _resourceCell1 = new ResourceCell(_cell1);
            _resourceCell2 = new ResourceCell(_cell2);
            _resourceCell3 = new ResourceCell(_cell3);
            _clear.onClick.AddListener(ClearClicked);
            foreach (var resourceButton in _resourceButtons)
            {
                resourceButton.Clicked += ResourceButtonOnClicked;
            }
        }

        private void ClearClicked()
        {
            if (_resourceCell1.Active)
            {
                Game.Instance.ResourceBank[_resourceCell1.ResourceType]++;
            }
            if (_resourceCell2.Active)
            {
                Game.Instance.ResourceBank[_resourceCell2.ResourceType]++;
            }
            if (_resourceCell3.Active)
            {
                Game.Instance.ResourceBank[_resourceCell3.ResourceType]++;
            }
            Clear();
        }

        private void Clear()
        {
            _resourceCell1.Active = false;
            _resourceCell2.Active = false;
            _resourceCell3.Active = false;
        }

        private void ResourceButtonOnClicked(ResourceType type)
        {
            if (Game.Instance.ResourceBank[type] <= 0)
            {
                return;
            }
            if (!_resourceCell1.Active)
            {
                _resourceCell1.Active = true;
                _resourceCell1.ResourceType = type;
                Game.Instance.ResourceBank[type]--;
                return;
            }
            if (!_resourceCell2.Active)
            {
                _resourceCell2.Active = true;
                _resourceCell2.ResourceType = type;
                Game.Instance.ResourceBank[type]--;
                return;
            }
            if (!_resourceCell3.Active)
            {
                _resourceCell3.Active = true;
                _resourceCell3.ResourceType = type;
                Game.Instance.ResourceBank[type]--;
                ApplyReceipt();
            }
        }

        private void ApplyReceipt()
        {
            var obj = _receipts.GetObjectByReceipt(
                _resourceCell1.ResourceType, 
                _resourceCell2.ResourceType,
                _resourceCell3.ResourceType);
            _inventory.AddToInventory(obj);
            Clear();
        }
    }

    internal class ResourceCell
    {
        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                Image.gameObject.SetActive(_active);
            }
        }

        public Image Image;
        private ResourceType _resourceType;
        private bool _active;

        public ResourceType ResourceType
        {
            get => _resourceType;
            set
            {
                _resourceType = value;
                Image.sprite = Game.Instance.ResourceInfoManager.GetInfo(value).Icon;
            }
        }

        public ResourceCell(Image image)
        {
            Image = image;
        }
    }
}