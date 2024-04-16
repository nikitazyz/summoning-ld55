using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public class DamageFX : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _tint;
        private IDamageable _damageable;
        private bool isPlaing;

        public IDamageable Damageable
        {
            get => _damageable;
            protected set
            {
                if (_damageable != null)
                {
                    _damageable.Health.Damaged -= HealthOnDamaged;
                }
                _damageable = value;
                if (_damageable != null)
                {
                    _damageable.Health.Damaged += HealthOnDamaged;
                }
            }
        }

        private void HealthOnDamaged(int arg1, int arg2)
        {
            if (isPlaing)
            {
                return;
            }
            StartCoroutine(Damage());
        }

        IEnumerator Damage()
        {
            isPlaing = true;
            var c = _spriteRenderer.color;
            _spriteRenderer.color = _tint;
            yield return new WaitForSeconds(0.4f);
            _spriteRenderer.color = c;
            isPlaing = false;
        }
    }
}