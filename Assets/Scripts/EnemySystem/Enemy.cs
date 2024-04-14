using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ITargeter
{
    public event Action Dead;
    
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float speed = 1;
    [SerializeField] private TargetSearcher targetSearcher;

    public Transform defaultTarget;
    private Transform target;

    private Health _health;

    public Transform Target { get => target; set => target = value; }

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
        if (target == null)
        {
            target = targetSearcher.FindTarget() ?? defaultTarget;
        }
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
