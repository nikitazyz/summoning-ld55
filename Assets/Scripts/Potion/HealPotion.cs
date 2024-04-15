using System;
using UnityEngine;

namespace Potion
{
    public class HealPotion : MonoBehaviour
    {
        [SerializeField] private int _heal;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;

        private void Start()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

            foreach (var col in colliders)
            {
                var damageable = col.GetComponent<IDamageable>();
                damageable?.Health.Heal(_heal);
            }
        }
    }
}