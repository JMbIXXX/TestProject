
using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy
{
    public class CharacterEnemy : Character
    {
        [SerializeField] private List<GameObject> _itemsForDrop = new List<GameObject>();
        private void Start()
        {
            healthBar = GetComponentInChildren<HealthBar>();
            healthBar.SetHealth();
        }
        public override bool IsEnemyDead()
        {
            return isEnemyDead;
        }
        public override void TakeDamage(float damage)
        {
            currentHealth -= damage;
            

            if (currentHealth > 0)
            {
                healthBar.GetCurrentHealth(currentHealth);
            }
            else
            {
                currentHealth = 0;
                
                healthBar.gameObject.SetActive(false);
                Death();
            }
        }


        private void Death()
        {
            var random = Random.Range(0, _itemsForDrop.Count);
            //Instantiate( _itemsForDrop[random].gameObject, transform, true);
            Instantiate(_itemsForDrop[random].gameObject, transform.position, Quaternion.Euler(0f, 0f, 0f));
            Destroy(gameObject);
        }
    }
}
