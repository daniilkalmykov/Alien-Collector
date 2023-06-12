using System.Collections.Generic;
using System.Linq;
using Blinders;
using GameLogic;
using Interfaces;
using UnityEngine;

namespace Player
{
    public sealed class PlayerMovement : MonoBehaviour , IMoveable
    {
        [SerializeField] private List<Target> _targets = new();
        [SerializeField] private MoveCubeBlinder _moveCubeBlinder;
        
        private Target _currentTarget;
        
        [field: SerializeField] public float Speed { get; private set; }

        private void OnDisable()
        {
            _moveCubeBlinder.MoveCube.MovesCountSet -= OnMovesCountSet;
        }

        private void Update()
        {
            if (_currentTarget == null || transform.position == _currentTarget.transform.position)
                return;

            Move(Time.deltaTime);
        }

        public void Move(float deltaTime)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _currentTarget.transform.position, Speed * deltaTime);
        }
        
        public void Init(MoveCubeBlinder moveCubeBlinder)
        {
            _moveCubeBlinder = moveCubeBlinder;
            
            _moveCubeBlinder.MoveCube.MovesCountSet += OnMovesCountSet;
        }

        private void OnMovesCountSet(int movesCount)
        {
            SetTarget(movesCount);
        }

        private void SetTarget(int movesCount)
        {
            var currentTargetId = _currentTarget == null ? 0 : _currentTarget.Id;

            int newTargetId;
            
            if (currentTargetId + movesCount > _targets.Count)
            {
                movesCount -= _targets.Count - currentTargetId;

                newTargetId = movesCount;
            }
            else
            {
                newTargetId = currentTargetId + movesCount;
            }

            _currentTarget = _targets.FirstOrDefault(target => target.Id == newTargetId);
        }
    }
}