using TowerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private Tower _tower;
        [SerializeField] private Button _replay;
        [SerializeField] private Button _mainMenu;
        [SerializeField] private GameObject _gameOverPanel;
        
        private void Start()
        {
            _replay.onClick.AddListener(OnReplay);
            _mainMenu.onClick.AddListener(OnMainMenu);
            _tower.Health.ValueChanged += HealthOnValueChanged;
        }

        private void HealthOnValueChanged(int obj)
        {
            if (obj <= 0)
            {
                _gameOverPanel.SetActive(true);
                Time.timeScale = 0;
            }
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
    }
}