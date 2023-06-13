using System;
using Enums;
using GameLogic;
using Interfaces;
using Models;
using UnityEngine;

namespace Player
{
    public sealed class PlayerMovement : MonoBehaviour , IMoveable
    {
        [SerializeField] private Target _startTarget;

        private float _startSpeed;
        private bool _isWaiting;

        public event Action<float> SpeedChanged;
        
        [field: SerializeField] public float Speed { get; private set; }
        
        public PlayerTargetSetter TargetSetter { get; private set; }

        private void OnDisable()
        {
            TargetSetter.Deactivate();
        }

        private void Start()
        {
            _startSpeed = Speed;
        }

        private void Update()
        {
            if (TargetSetter.CurrentTarget == null || TargetSetter.MovesCount <= 0)
                return;

            if (transform.position == TargetSetter.CurrentTarget.transform.position)
            {
                if (TargetSetter.CurrentTarget.TargetStatus == TargetStatus.ChoosingDirection && _isWaiting == false)
                {
                    _isWaiting = true;
                    Speed = 0;
                    
                    SpeedChanged?.Invoke(Speed);
                }
                else
                {
                    TargetSetter.SetCurrentTarget(0);
                }
                
                TargetSetter.TryReduceMovesCount();
            }
            
            Move(Time.deltaTime);
        }

        public void InitTargetSetter(MoveCube moveCube)
        {
            TargetSetter = new PlayerTargetSetter(_startTarget, moveCube);
        }
        
        public void Move(float deltaTime)
        {
            var targetPosition = TargetSetter.CurrentTarget.transform.position;
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * deltaTime);
        }
        
        public void ResetSpeed()
        {
            Speed = _startSpeed;
            
            SpeedChanged?.Invoke(Speed);
        }
    }
}