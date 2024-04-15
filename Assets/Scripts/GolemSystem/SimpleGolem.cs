using System;
using UnityEngine;

namespace GolemSystem
{
    public class SimpleGolem : Golem
    {
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _attackInterval;
        [SerializeField] private int _damage;
        [SerializeField] private LayerMask _attackMask;

        private float _timestamp;
        
        private void Update()
        {
            Attack();
        }
        
        private void Attack()
        {

            if (Time.time - _timestamp < _attackInterval)
            {
                return;
            }

            _timestamp = Time.time;

            Collider2D[] colliders = new Collider2D[50];
            Physics2D.OverlapCircleNonAlloc(transform.position, _attackRadius, colliders, _attackMask);

            foreach (var collider in colliders)
            {
                if (!collider)
                {
                    continue;
                }
                var damageable = collider.GetComponent<IDamageable>();
                damageable.Health.TakeDamage(_damage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
        }
    }
}