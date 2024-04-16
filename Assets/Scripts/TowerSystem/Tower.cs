using System;
using UI;
using UnityEngine;

namespace TowerSystem
{
    public class Tower : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private float _regenerationInterval = 3f;
        [SerializeField] private int _regenerationAmount = 6;

        [SerializeField] private float _attackInterval = 1f;
        [SerializeField] private float _attackRadius = 2f;
        [SerializeField] private float _kickForce = 20f;
        [SerializeField] private int _damage;
        [SerializeField] private LayerMask _enemy;

        [SerializeField] private DamageZone _damageZone;

        private float _timestamp;
        private float _regenerationTimeStamp;
        public Health Health { get; private set; }

        private void Awake()
        {
            Health = new Health(maxHealth);
            Health.Damaged += (i, i1) => Debug.Log("TowerDamaged");
            Health.Damaged += (_, _) => _regenerationTimeStamp = Time.time;
        }

        private void Update()
        {
            Regeneration();
            Attack();
        }

        private void Regeneration()
        {
            if (Time.time - _regenerationTimeStamp < _regenerationInterval)
            {
                return;
            }

            _regenerationTimeStamp = Time.time;
            Health.Heal(_regenerationAmount);
        }

        private void Attack()
        {
            if (Time.time - _timestamp < _attackInterval)
            {
                return;
            }

            _timestamp = Time.time;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius, _enemy);
            if (colliders.Length > 0)
            {
                _damageZone.Run();
            }
            foreach (var collider2D1 in colliders)
            {
                var damageable = collider2D1.GetComponent<IDamageable>();
                var rigidBody = collider2D1.GetComponent<Rigidbody2D>();
                
                damageable.Health.TakeDamage(_damage);
                var direction = rigidBody.position - (Vector2)transform.position;
                direction.Normalize();
                rigidBody.AddForce(direction * _kickForce, ForceMode2D.Impulse);
            }
        }
    }
}