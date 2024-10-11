using Components;
using Zenject;
using UnityEngine;

namespace Controllers
{
    public sealed class FireController : MonoBehaviour
    {
        private AttackComponent _attackComponent;

        [Inject]
        public void Construct(AttackComponent attackComponent)
        {
            _attackComponent = attackComponent;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))  // ���� �����
            {
                _attackComponent.Attack(false);
            }
            else if (Input.GetMouseButtonDown(0))  // ��������
            {
                _attackComponent.Attack(true);
            }
        }
    }
}
