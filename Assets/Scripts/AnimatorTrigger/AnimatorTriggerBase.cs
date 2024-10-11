using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimatorTriggerBase : MonoBehaviour
    {
        protected Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetTrigger(int triggerHash)
        {
            _animator.SetTrigger(triggerHash);
        }
    }
}
