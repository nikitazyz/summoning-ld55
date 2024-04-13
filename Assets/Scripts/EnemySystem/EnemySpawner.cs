using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;
    [SerializeField] private Rect _spawnBounds;

    [SerializeField] private float _interval;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(_interval);
        var instance = Instantiate(_enemyPrefab);
        instance.GetComponent<TargetSearcher>().defaultTarget = _target;
        float x = Random.Range(_spawnBounds.min.x, _spawnBounds.max.x);
        float y = Random.Range(_spawnBounds.min.y, _spawnBounds.max.y);

        Vector3 pos = transform.position + new Vector3(x, y, 0);
        instance.transform.position = pos;
    }

}
