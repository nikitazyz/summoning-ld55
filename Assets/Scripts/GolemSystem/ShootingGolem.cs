using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace GolemSystem
{
    public class ShootingGolem : Golem
    {
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private float _shootInterval;
        [SerializeField] private float _shootDistance;
        [SerializeField] private int _damage;
        [SerializeField] private LayerMask _layerMask;

        private float _timestamp;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (Time.time - _timestamp < _shootInterval)
            {
                return;
            }

            _timestamp = Time.time;
            ShootProjectile();
        }

        private void ShootProjectile()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, _shootDistance, _layerMask);

            if (colliders.Length == 0)
            {
                return;
            }
            var target = colliders.OrderBy(c => c ? Vector2.Distance(transform.position, c.transform.position) : float.MaxValue).First().transform;
            
            
            if (target != null && projectilePrefab != null && shootingPoint != null)
            {
                StartCoroutine(Shoot(target));
            }
        }

        private IEnumerator Shoot(Transform target)
        {
            _animator.SetTrigger("Fire");
            yield return new WaitForSeconds(0.5f);
            Projectile projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
            Vector3 shootingDirection = (target.position - shootingPoint.position).normalized;
                
            projectile.Initialize(_damage, shootingDirection);
            
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _shootDistance);
        }
    }
}