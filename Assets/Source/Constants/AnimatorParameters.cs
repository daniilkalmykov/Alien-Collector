using UnityEngine;

namespace Constants
{
    public static class AnimatorParameters
    {
        public static readonly int IsWalking = Animator.StringToHash("IsWalking");
        public static readonly int Shoot = Animator.StringToHash("Shoot");
        public static readonly int Hit = Animator.StringToHash("Hit");
        public static readonly int Die = Animator.StringToHash("Die");
    }
}