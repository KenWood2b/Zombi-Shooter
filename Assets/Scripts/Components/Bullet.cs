using Components;
using UnityEngine;

namespace GameObjects
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private float lifetime = 5f;  // ����� ����� ����

        private void Start()
        {
            // ���������� ���� ����� �������� �����
            Destroy(gameObject, lifetime);
        }

        private void OnCollisionEnter(Collision other)
        {
            // ���������, ���� �� � ������� ��������� ��������
            HealthComponent healthComponent = other.gameObject.GetComponentInParent<HealthComponent>();
            Debug.Log($"[{other.collider.name}]");

            if (healthComponent != null)
            {
                // ������� ���� �������
                healthComponent.TakeDamage(damage);
                Destroy(gameObject); // ���������� ���� ����� ������������
            }
        }
    }
}
