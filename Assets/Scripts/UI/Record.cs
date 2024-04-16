using UnityEngine;

namespace UI
{
    public class Record : MonoBehaviour
    {
        private const string RecordTimeKey = "BestTime";

        private float _bestTime;

        public float BestTime => _bestTime;

        void Start()
        {
            _bestTime = LoadBestTime();
        }

        public bool UpdateBestTime(float currentTime)
        {
            if (currentTime > _bestTime || _bestTime == 0)
            {
                Debug.Log("Save best");
                SaveBestTime(currentTime);
                return true;
            }

            return false;
        }

        private void SaveBestTime(float time)
        {
            _bestTime = time;
            PlayerPrefs.SetFloat(RecordTimeKey, time);
            PlayerPrefs.Save();
        }

        private float LoadBestTime()
        {
            return PlayerPrefs.GetFloat(RecordTimeKey, 0);
        }
    }
}