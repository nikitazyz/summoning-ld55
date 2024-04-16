using System;
using UnityEngine;

namespace UI
{
    public class Escape : MonoBehaviour
    {
        [SerializeField] private InventoryOpen _inventoryOpen;
        [SerializeField] private Pause _pause;

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

            _pause.OnPause();
        }
    }
}