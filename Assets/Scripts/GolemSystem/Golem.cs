using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth;
    public Health Health { get; private set; }

    private void Awake()
    {
        Health = new Health(maxHealth);
        Health.Damaged += (value, _) =>
        {
            if (value == 0) 
                Destroy(gameObject);
        };
    }
}
