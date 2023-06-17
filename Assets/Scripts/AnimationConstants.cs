using UnityEngine;

namespace DefaultNamespace
{
    public static class AnimationConstants
    {
        public static readonly int Eat = Animator.StringToHash("Eat");
        public static readonly int Sleep = Animator.StringToHash("Sleep");
        public static readonly int LookAt = Animator.StringToHash("LookAt");
    }
}