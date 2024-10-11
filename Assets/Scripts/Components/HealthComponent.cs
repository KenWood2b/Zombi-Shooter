using UnityEngine;

namespace Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        private int currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            Debug.Log($"Health: {currentHealth}");

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // Логика смерти персонажа
            Debug.Log("Character Died");
            Destroy(gameObject);
        }
    }
}