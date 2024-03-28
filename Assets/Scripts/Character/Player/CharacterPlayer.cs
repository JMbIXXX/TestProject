using InGameObjects.Items;
using UI;
using UnityEngine;

namespace Character.Player
{
    public class CharacterPlayer : Character
    {
        [SerializeField] private Backpack _backpack;
        [SerializeField] private GameObject _wastedPanel;
        private void Start()
        {
            healthBar = GetComponentInChildren<HealthBar>();
            healthBar.SetHealth();
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

        public void GetItem(Item item)
        {
            _backpack.GetItemInBackpack(item);
        }

        public void Death()
        {
            _wastedPanel.SetActive(true);
        }
        public override bool IsEnemyDead()
        {
            return true;
        }
    }
}
