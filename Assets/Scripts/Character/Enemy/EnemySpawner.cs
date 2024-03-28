using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Character.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
        [SerializeField] private List<GameObject> _enemiesPool = new List<GameObject>();

        private void Start()
        {
            SpawnEnemies();
        }

        public void SpawnEnemies()
        {
            for (int i = 0; i < 3; i++)
            {
                var enemy = Instantiate(_enemies[0].gameObject, new Vector3(transform.position.x +Random.Range(-5f, 5f), transform.position.y +Random.Range(-5f, 5f)), Quaternion.identity, transform);
                _enemiesPool.Add(enemy);
            }
        }

        public void DeleteEnemies()
        {
            for (int i = 0; i < _enemiesPool.Count; i++)
            {
                if (_enemiesPool[i] != null)
                {
                    Destroy(_enemiesPool[i].gameObject);
                }
            }
        }
    }
}
