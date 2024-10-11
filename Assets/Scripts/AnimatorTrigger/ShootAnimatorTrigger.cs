using UnityEngine;

namespace Animations
{
    public class ShootAnimatorTrigger : AnimatorTriggerBase
    {
        private static readonly int Shoot = Animator.StringToHash("Shoot");

        public void SetShootTrigger()
        {
            SetTrigger(Shoot);
        }
    }
}
