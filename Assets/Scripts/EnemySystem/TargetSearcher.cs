using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private Enemy _enemy;

    public Transform defaultTarget;

    private Transform _enemyTarget;

    void Start()
    {
        
    }


    void Update()
    {
        if (!_enemyTarget)
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, _radius, _enemyMask);
            if (collider != null)
            {
                _enemyTarget = collider.transform;
            }
        }


        if (!_enemy.target || _enemy.target != _enemyTarget)
        {
            _enemy.target = _enemyTarget ? _enemyTarget : defaultTarget;
            return;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
