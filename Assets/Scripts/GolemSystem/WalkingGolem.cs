using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingGolem : Golem
{
    public float maxDistance = 10f;
    private Vector3 initialPosition;
    [SerializeField] private TargetSearcher searcher;

    private Transform target;
    [SerializeField] private float speed;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        SearchAndMove();
    }

    // Метод поиска цели и перемещения к ней
    private void SearchAndMove()
    {
        if (searcher != null)
        {
            if (target)
            {
                return;
            }
            target = searcher.FindTarget();
            if (target)
            {
                float distance = Vector3.Distance(initialPosition, transform.position);
                if (distance < maxDistance)
                {
                    var direction = target.position - transform.position;
                    direction = Vector3.ClampMagnitude(direction, speed);
                    transform.Translate(direction * Time.deltaTime);
                }
            }
        }
    }
}
