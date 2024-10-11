using UnityEngine;

namespace Animations
{
    public class PunchAnimatorTrigger : AnimatorTriggerBase
    {
        private static readonly int Punch = Animator.StringToHash("Punch");

        public void SetPunchTrigger()
        {
            SetTrigger(Punch);
        }
    }
}
