using System;
using UnityEngine;

namespace GolemSystem
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        private int damage = 0;
        private Vector3 movementDirection = Vector3.forward;
        [SerializeField] private float speed = 10f; // Default speed of the projectile
        [SerializeField] private LayerMask layermask;
        [SerializeField] private float _lifeTime = 10;
        private float _timestamp;

        public void Initialize(int newDamage, Vector3 newDirection)
        {
            damage = newDamage;
            movementDirection = newDirection.normalized;
            _timestamp = Time.time;
        }

        void Start()
        {
            MoveProjectile();
        }

        private void Update()
        {
            if (Time.time - _timestamp > _lifeTime)
            {
                Destroy(gameObject);
            }
        }

        private void MoveProjectile()
        {
            if (rigidbody != null)
            {
                rigidbody.velocity = movementDirection * speed;
            }
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (layermask != (layermask | (1 << collider2D.gameObject.layer)))
            {
                return;
            }
            
            if (collider2D.TryGetComponent(out IDamageable damageable))
            {
                damageable.Health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}