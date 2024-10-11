using Animations;
using Zenject;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour
    {
        private ShootAnimatorTrigger _shootAnimatorTrigger;
        private PunchAnimatorTrigger _punchAnimatorTrigger;
        private WeaponComponent _weaponComponent;
        private Animator _animator;

        private bool isPunching;

        [Inject]
        public void Construct(ShootAnimatorTrigger shootAnimatorTrigger, PunchAnimatorTrigger punchAnimatorTrigger, WeaponComponent weaponComponent, Animator animator)
        {
            _shootAnimatorTrigger = shootAnimatorTrigger;
            _punchAnimatorTrigger = punchAnimatorTrigger;
            _weaponComponent = weaponComponent;
            _animator = animator;
        }

        public void Attack(bool isShoot)
        {
            if (isShoot && _weaponComponent.CanFire)
            {
                _shootAnimatorTrigger.SetTrigger(Animator.StringToHash("Shoot"));  // ��������� �������� ��������
                _weaponComponent.Fire();  // �������� ����� ��������
                isPunching = false;
            }
            else
            {
                Debug.Log("Start Punching");
                _punchAnimatorTrigger.SetTrigger(Animator.StringToHash("Punch"));
                isPunching = true;  // ������������� ���� �����
            }
        }

        public bool IsPunching()
        {
            if (isPunching)
            {
                Debug.Log("���� �������");

                if (_animator.GetLayerWeight(1) > 0)
                {
                    AnimatorStateInfo currentState = _animator.GetCurrentAnimatorStateInfo(1);
                    if (currentState.IsName("Punch") && currentState.normalizedTime >= 1.0f)
                    {
                        isPunching = false;
                        _animator.SetLayerWeight(1, 0);
                        Debug.Log("Punch ��������, ��� ���� �������, �������� ����� ��������� �����");
                    }
                }
            }
            return isPunching;
        }
    }
}
