using UnityEngine;

namespace Character
{
    public enum CharacterType
    {
        Player,
        Enemy
    }
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] protected CharacterType characterType;
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float currentHealth;
        [SerializeField] protected float movementSpeed;
        [SerializeField] protected float damage;
        [SerializeField] protected HealthBar healthBar;
        protected bool isEnemyDead;
        public float GetMovementSpeed()
        {
            return movementSpeed;
        }

        public float GetDamage()
        {
            return damage;
        }
        public float GetMaxHealth()
        {
            return maxHealth;
        }
        public CharacterType GetCharactertype()
        {
            return characterType;
        }

        public void SetHealth(float value)
        {
            currentHealth = value;
            maxHealth = currentHealth;
            healthBar.gameObject.SetActive(true);
            healthBar.SetHealth();
            
        }
        
        public abstract void TakeDamage(float damage);
        public abstract bool IsEnemyDead();
    }
}
