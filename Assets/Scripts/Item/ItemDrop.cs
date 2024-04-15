using System;
using UnityEngine;

namespace Item
{
    public class ItemDrop : MonoBehaviour
    {
        [SerializeField] private ItemView _itemView;
        [SerializeField] private float _time = 10;
        [SerializeField] private float _speed = 10;

        private float _timestamp;
        public ResourceType ResourceType
        {
            get => _itemView.ResourceType;
            set => _itemView.ResourceType = value;
        }

        private void Start()
        {
            _timestamp = Time.time;
        }

        private void Update()
        {
            transform.Translate((Vector3.up + Vector3.left) * _speed * Time.deltaTime);
            if (Time.time - _timestamp > _time)
            {
                Destroy(gameObject);
            }
        }
    }
}