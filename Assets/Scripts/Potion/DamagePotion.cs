using System;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Potion
{
    public class DamagePotion : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private DamageZone _damageZone;

        private void Start()
        {
            _damageZone.Run();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

            foreach (var col in colliders)
            {
                var damageable = col.GetComponent<IDamageable>();
                damageable?.Health.TakeDamage(_damage);
            }
        }
    }
}