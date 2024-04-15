using UnityEngine;

namespace UI
{
    public class HPBar : MonoBehaviour
    {
        private IDamageable _damageable;
        [SerializeField] private RectTransform _fill;

        public IDamageable Damageable
        {
            get => _damageable;
            protected set
            {
                if (_damageable != null)
                {
                    _damageable.Health.ValueChanged -= HealthOnValueChanged;
                }
                _damageable = value;
                if (_damageable != null)
                {
                    _damageable.Health.ValueChanged += HealthOnValueChanged;
                }
            }
        }

        private void HealthOnValueChanged(int value)
        {
            float delta = (float)value / Damageable.Health.MaxValue;
            Debug.Log(delta);
            _fill.sizeDelta = new Vector2(_fill.parent.GetComponent<RectTransform>().sizeDelta.x * delta, _fill.sizeDelta.y);
        }
    }
}