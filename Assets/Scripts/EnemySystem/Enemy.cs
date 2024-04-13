using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float speed = 1;
    public Transform target;

    private Health _health;

    private void Awake()
    {
        _health = new Health(maxHealth);
    }

    private void Update()
    {
        Move();
        
    }

    public void Move()
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
