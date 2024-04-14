using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action Dead;
    
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float speed = 1;
    public Transform target;

    private Health _health;

    private void Awake()
    {
        _health = new Health(maxHealth);
        _health.Damaged += HealthOnDamaged;
    }

    private void HealthOnDamaged(int health, int damage)
    {
        if (health == 0)
        {
            Dead?.Invoke();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        if (target == null)
        {
            return;
        }

        var direction = target.position - transform.position;
        direction = Vector3.ClampMagnitude(direction, speed);

        transform.Translate(direction * Time.deltaTime);
    }
}
