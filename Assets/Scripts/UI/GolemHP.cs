using System;
using UnityEngine;

namespace UI
{
    public class GolemHP : HPBar
    {
        [SerializeField] private Golem _golem;

        private void Start()
        {
            Damageable = _golem;
        }
    }
}