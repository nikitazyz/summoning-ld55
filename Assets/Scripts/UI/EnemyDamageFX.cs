using System;
using UnityEngine;

namespace UI
{
    public class EnemyDamageFX : DamageFX
    {
        [SerializeField] private Enemy _enemy;

        private void Start()
        {
            Damageable = _enemy;
        }
    }
}