using System;
using UnityEngine;

namespace UI
{
    public class Escape : MonoBehaviour
    {
        [SerializeField] private InventoryOpen _inventoryOpen;

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }

            if (_inventoryOpen.IsOpen)
            {
                _inventoryOpen.ToggleInventory();
                return;
            }
        }
    }
}