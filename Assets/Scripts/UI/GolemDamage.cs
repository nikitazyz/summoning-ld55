using UnityEngine;

namespace UI
{
    public class GolemDamage : DamageFX
    {
        [SerializeField] private Golem _enemy;

        private void Start()
        {
            Damageable = _enemy;
        }
    }
}