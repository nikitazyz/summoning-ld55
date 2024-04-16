using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public event Action Dead;
    
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float speed = 1;
    [SerializeField] private TargetSearcher targetSearcher;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackInterval;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;

    public Transform defaultTarget;
    private Transform target;

    private Health _health;

    private float _timespan;

    public Health Health => _health;

    private void Awake()
    {
        _health = new Health(maxHealth);
        _health.Damaged += HealthOnDamaged;
    }

    private void Start()
    {
        target = defaultTarget;
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
        if (!target || target == defaultTarget)
        {
            target = targetSearcher.FindTarget() ?? defaultTarget;
        }
        
        Move();
        Attack();
    }

    private void Move()
    {
        _animator.SetBool("Walking", false);
        if (target == null)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) < _attackDistance)
        {
            return;
        }

        var direction = target.position - transform.position;
        direction = Vector3.ClampMagnitude(direction, speed);

        transform.Translate(direction * Time.deltaTime);
        _animator.SetBool("Walking", true);
    }

    private void Attack()
    {
        if (!target)
        {
            return;
        }
        
        if (Vector2.Distance(transform.position, target.position) >= _attackDistance)
        {
            return;
        }

        if (Time.time - _timespan < _attackInterval)
        {
            return;
        }

        _timespan = Time.time;

        Debug.Log("Attack");
        var damageable = target.GetComponent<IDamageable>();
        if (damageable == null)
        {
            return;
        }
        damageable.Health.TakeDamage(_damage);
    }
}
