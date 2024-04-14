using System;
using Core;
using UnityEngine;

namespace Item
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public ResourceType ResourceType
        {
            get => _resourceType;
            set
            {
                _resourceType = value;
                _spriteRenderer.sprite = Game.Instance.ResourceInfoManager.GetInfo(value).Icon;
            }
        }

        private void Awake()
        {
            _spriteRenderer.sprite = Game.Instance.ResourceInfoManager.GetInfo(_resourceType).Icon;
        }
    }
}