using TMPro;
using TowerSystem;
using UnityEngine;

namespace UI
{
    public class GameTimer : MonoBehaviour
    {
        public TMP_Text timerText;
        public TMP_Text recordText;
        private float startTime;
        private bool gameIsOver = false;
        public float TimeElapsed { get; private set; }
        [SerializeField] private Tower _tower;
        [SerializeField] private Record _record;

        void Start()
        {
            _tower.Health.ValueChanged += HealthOnValueChanged;
            startTime = Time.time;
        }

        private void HealthOnValueChanged(int obj)
        {
            if (obj <= 0)
            {
                EndGame();
            }
        }

        void Update()
        {
            if (!gameIsOver)
            {
                float timeElapsed = Time.time - startTime;
                TimeElapsed = timeElapsed;
                string minutes = ((int) timeElapsed / 60).ToString("00");
                string seconds = ((int) timeElapsed % 60).ToString("00");
                timerText.text = $"{minutes}:{seconds}";
            }
        }

        public void EndGame()
        {
            if (gameIsOver)
            {
                return;
            }
            gameIsOver = true;
            bool newRecord = _record.UpdateBestTime(TimeElapsed);
            Debug.Log(newRecord);
            if (newRecord)
            {
                Debug.Log("New record");
                var timeElapsed = TimeElapsed;
                string minutes = ((int) timeElapsed / 60).ToString("00");
                string seconds = ((int) timeElapsed % 60).ToString("00");
                recordText.text = $"New record: {minutes}:{seconds}";
            }
            else
            {
                var timeElapsed = TimeElapsed;
                string minutes = ((int) timeElapsed / 60).ToString("00");
                string seconds = ((int) timeElapsed % 60).ToString("00");
                
                var bestTime = _record.BestTime;
                string bminutes = ((int) bestTime / 60).ToString("00");
                string bseconds = ((int) bestTime % 60).ToString("00");
                recordText.text = $"Current run: {minutes}:{seconds}\nBest time: {bminutes}:{bseconds}";
            }
        }
    }
}