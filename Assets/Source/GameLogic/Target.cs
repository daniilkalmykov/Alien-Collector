using System;
using Enums;
using UnityEngine;

namespace GameLogic
{
    public sealed class Target : MonoBehaviour
    {
        [SerializeField] private Target[] _nextTargets;
        
        [field: SerializeField] public TargetStatus TargetStatus { get; private set; }
        
        public Target NextTarget { get; private set; }

        public void TrySetNextTarget(int id)
        {
            if (id < 0 || id >= _nextTargets.Length)
                throw new ArgumentNullException();

            NextTarget = _nextTargets[id];
        }
    }
}