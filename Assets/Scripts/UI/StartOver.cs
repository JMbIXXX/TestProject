using System.Security.Cryptography.X509Certificates;
using Character.Enemy;
using UnityEngine;

namespace UI
{
    public class StartOver : MonoBehaviour
    {
        [SerializeField] private Character.Character _character;
        [SerializeField] private Backpack _backpack;
        [SerializeField] private EnemySpawner _enemySpawner;

        public void StartAgain()
        {
            _character.SetHealth(100f);
            _character.gameObject.transform.position = new Vector2(0f, 0f);
            _backpack.DeleteAllItems();
            _enemySpawner.DeleteEnemies();
            _enemySpawner.SpawnEnemies();
            gameObject.SetActive(false);
        }
    }
}
