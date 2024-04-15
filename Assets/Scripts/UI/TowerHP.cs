using System;
using TowerSystem;
using UnityEngine;

namespace UI
{
    public class TowerHP : HPBar
    {
        [SerializeField] private Tower _tower;

        private void Start()
        {
            Damageable = _tower;
        }
    }
}