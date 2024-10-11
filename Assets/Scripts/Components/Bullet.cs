using Components;
using UnityEngine;

namespace GameObjects
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private float lifetime = 5f;  // Время жизни пули

        private void Start()
        {
            // Уничтожаем пулю через заданное время
            Destroy(gameObject, lifetime);
        }

        private void OnCollisionEnter(Collision other)
        {
            // Проверяем, есть ли у объекта компонент здоровья
            HealthComponent healthComponent = other.gameObject.GetComponentInParent<HealthComponent>();
            Debug.Log($"[{other.collider.name}]");

            if (healthComponent != null)
            {
                // Наносим урон объекту
                healthComponent.TakeDamage(damage);
                Destroy(gameObject); // Уничтожаем пулю после столкновения
            }
        }
    }
}
