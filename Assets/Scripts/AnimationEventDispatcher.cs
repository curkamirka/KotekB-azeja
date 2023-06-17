using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AnimationEventDispatcher : MonoBehaviour
    {
        public event Action<string> OnAnimationTriggered;

        public void AnimationTrigger(string animationName)
        {
            OnAnimationTriggered?.Invoke(animationName);
        }
    }
}