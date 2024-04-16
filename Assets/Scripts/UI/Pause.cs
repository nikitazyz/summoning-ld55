using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Pause : MonoBehaviour
    {
        [SerializeField] private Button _pause;
        [SerializeField] private Button _replay;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private GameObject _pausePanel;

        [SerializeField] private InventoryOpen _inventoryOpen;

        private bool isPause;
        
        private void Awake()
        {
            _pause.onClick.AddListener(OnPause);
            _replay.onClick.AddListener(OnReplay);
            _mainMenu.onClick.AddListener(OnMainMenu);
        }

        private void OnMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        private void OnReplay()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void OnPause()
        {
            if (_inventoryOpen.IsOpen)
            {
                return;
            }

            isPause = !isPause;
            Time.timeScale = isPause ? 0 : 1;
            _pausePanel.SetActive(isPause);
        }
    }
}