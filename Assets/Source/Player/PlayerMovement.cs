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
        
        private readonly List<Target> _currentTargets = new();
        
        private Target _currentTarget;
        private bool _isWaiting;

        [field: SerializeField] public float Speed { get; private set; }

        private void OnDisable()
        {
            _moveCubeBlinder.MoveCube.MovesCountSet -= OnMovesCountSet;
        }

        private void Update()
        {
            if (_currentTarget == null)
                return;

            if (transform.position == _currentTarget.transform.position && _currentTargets.Count > 0)
            {
                _currentTargets.RemoveAt(0);

                if (_currentTargets.Count > 0)
                    _currentTarget = _currentTargets[0];
            }
            
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
            SetCurrentTargets(movesCount);
        }

        private void SetCurrentTargets(int movesCount)
        {
            var currentTargetId = _currentTarget == null ? 0 : _currentTarget.Id;
            
            for (var i = 0; i < movesCount; i++)
            {
                currentTargetId = currentTargetId % _targets.Count + 1;
                _currentTargets.Add(_targets.FirstOrDefault(target => target.Id == currentTargetId));
            }

            _currentTarget = _currentTargets[0];
        }
    }
}