using System;
using System.Collections;
using System.Linq;
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
        [SerializeField] private Animator _animator;

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

            
            StartCoroutine(AttackProcess());
        }

        private IEnumerator AttackProcess()
        {
            Collider2D[] colliders = new Collider2D[50];
            Physics2D.OverlapCircleNonAlloc(transform.position, _attackRadius, colliders, _attackMask);

            if (colliders.Any(c => c))
            {
                _animator.SetTrigger("Attack");
            }

            yield return new WaitForSeconds(0.5f);
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