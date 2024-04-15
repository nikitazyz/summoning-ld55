using System;
using Core;
using Item;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace EnemySystem
{
    public class EnemyDrop : MonoBehaviour
    {
        [SerializeField] private DropWeight[] _drops;
        [SerializeField] private ItemDrop _dropPrefab;
        [SerializeField] private Enemy _enemy;
        
        private ResourceType GetRandomDropType()
        {
            int totalWeight = 0;
            foreach (var dropWeight in _drops)
            {
                totalWeight += dropWeight.Weight;
            }

            int randomValue = Random.Range(0, totalWeight);

            foreach (var dropWeight in _drops)
            {
                randomValue -= dropWeight.Weight;
                if (randomValue < 0)
                {
                    return dropWeight.Type;
                }
            }
            return _drops[^1].Type;
        }

        private void Awake()
        {
            _enemy.Dead += EnemyOnDead;
        }

        private void EnemyOnDead()
        {
            ResourceType type = GetRandomDropType();
            var instance = Instantiate(_dropPrefab, transform.position, Quaternion.identity);
            instance.ResourceType = type;
            Game.Instance.ResourceBank[type]++;
        }
    }
}