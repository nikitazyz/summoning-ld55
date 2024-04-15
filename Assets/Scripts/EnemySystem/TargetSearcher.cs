using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _enemyMask;

    public float Radius => _radius;

    public Transform FindTarget()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _radius, _enemyMask);
        if (collider != null)
        {
            return collider.transform;
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
