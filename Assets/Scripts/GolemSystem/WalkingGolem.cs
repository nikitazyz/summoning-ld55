using UnityEngine;

public class WalkingGolem : Golem
{
    public float maxDistance = 10f;
    private Vector3 initialPosition;
    [SerializeField] private TargetSearcher targetSearcher;
    [SerializeField] private float speed;
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackInterval;
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _attackMask;
    [SerializeField] private float _horizontalOffset;
    [SerializeField] private Animator _animator;

    private Transform target;
    private float _timestamp;
    private bool _isLeft;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (!target)
        {
            target = targetSearcher.FindTarget();
        }
        Attack();
        Move();
    }

    private void Move()
    {
        _animator.SetBool("Walking", false);
        if (target == null)
        {
            return;
        }

        var direction = target.position - transform.position;
        direction = Vector3.ClampMagnitude(direction, speed);
        if (Vector3.Distance(transform.position + direction * Time.deltaTime, initialPosition) > maxDistance)
        {
            return;
        }

        if (Vector2.Distance(transform.position, target.position) < _stopDistance)
        {
            return;
        }

        _isLeft = direction.x < 0;
        transform.Translate(direction * Time.deltaTime);
        _animator.SetBool("Walking", true);
    }

    private void Attack()
    {

        if (Time.time - _timestamp < _attackInterval)
        {
            return;
        }

        _timestamp = Time.time;

        Collider2D[] colliders = new Collider2D[50];
        Physics2D.OverlapCircleNonAlloc(transform.position + Vector3.right * (_horizontalOffset * (_isLeft ? -1 : 1)), _attackRadius, colliders, _attackMask);

        foreach (var collider in colliders)
        {
            if (!collider)
            {
                continue;
            }
            var damageable = collider.GetComponent<IDamageable>();
            damageable.Health.TakeDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(initialPosition, maxDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * _horizontalOffset, _attackRadius);
        Gizmos.DrawWireSphere(transform.position + Vector3.right * -_horizontalOffset, _attackRadius);
    }
}
