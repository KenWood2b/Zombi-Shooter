using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class MovementAnimatorController : AnimatorTriggerBase
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");

        // ����� ��� ��������� �������� � ��������
        public void SetSpeed(float speed)
        {
            Debug.Log($"Setting speed: {speed}");
            _animator.SetFloat(Speed, speed);
        }

        // ����� ��� ��������� �������� ������
        public void SetJumping(bool isJumping)
        {
            Debug.Log($"Setting jumping: {isJumping}");
            _animator.SetBool(IsJumping, isJumping);
        }
    }
}
