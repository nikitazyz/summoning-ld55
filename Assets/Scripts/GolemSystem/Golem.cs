using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public Health Health { get; private set; }

    private void Awake()
    {
        Health = new Health(maxHealth);
    }
}
