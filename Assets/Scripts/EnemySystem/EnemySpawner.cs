using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private Rect _spawnBounds;

    [SerializeField] private float _interval;
    [SerializeField] private int _initialMaxEnemies;
    [SerializeField] private float _maxEnemiesIncreaseInterval;
    [SerializeField] private int _maxEnemiesIncrease;

    private int _maxEnemies;

    private readonly List<Enemy> _enemies = new List<Enemy>();

    private void Start()
    {
        _maxEnemies = _initialMaxEnemies;
        StartCoroutine(SpawnRoutine());
        StartCoroutine(MaxEnemiesRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(_interval);
            if (_enemies.Count >= _maxEnemies)
            {
                continue;
            }
            var instance = Instantiate(_enemyPrefab);
            instance.defaultTarget = _target;
            float x = Random.Range(_spawnBounds.min.x, _spawnBounds.max.x);
            float y = Random.Range(_spawnBounds.min.y, _spawnBounds.max.y);

            Vector3 pos = transform.position + new Vector3(x, y, 0);
            instance.transform.position = pos;
            _enemies.Add(instance);
        }
    }

    private IEnumerator MaxEnemiesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_maxEnemiesIncreaseInterval);
            _maxEnemies += _maxEnemiesIncrease;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + (Vector3)_spawnBounds.center, _spawnBounds.size);
        float x = _spawnBounds.xMin;
        float y = _spawnBounds.yMin;
        float x1 = _spawnBounds.xMax;
        float y1 = _spawnBounds.yMax;
        
        Gizmos.DrawSphere(transform.position + new Vector3(x, y, 0), 0.1f);
        Gizmos.DrawSphere(transform.position + new Vector3(x1, y1, 0), 0.1f);
    }
}
