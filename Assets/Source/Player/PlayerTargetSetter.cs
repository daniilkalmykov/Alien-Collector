using Enums;
using GameLogic;
using Models;
using UnityEngine;
using UnityEngine.Windows;

namespace Player
{
    public sealed class PlayerTargetSetter
    {
        private readonly MoveCube _moveCube;

        public PlayerTargetSetter(Target target,  MoveCube moveCube)
        {
            CurrentTarget = target;
            _moveCube = moveCube;

            _moveCube.MovesCountSet += OnMovesCountSet;
        }

        public int MovesCount { get; private set; }
        public Target CurrentTarget { get; private set; }
        
        public void Deactivate()
        {
            _moveCube.MovesCountSet -= OnMovesCountSet;
        }

        public void TryReduceMovesCount()
        {
            if (MovesCount > 0)
                MovesCount--;
        }

        public void SetCurrentTarget(int id)
        {
            CurrentTarget.TrySetNextTarget(id);
            CurrentTarget = CurrentTarget.NextTarget;
        }
        
        private void OnMovesCountSet(int movesCount)
        {
            MovesCount = movesCount;
        }
    }
}