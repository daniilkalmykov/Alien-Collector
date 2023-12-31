using System;
using Constants;
using Enums;
using GameLogic;
using Interfaces;
using Models;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerMovement : MonoBehaviour , IMoveable
    {
        [SerializeField] private Target _startTarget;
        
        private float _startSpeed;
        private bool _isWaiting;
        private Animator _animator;

        public event Action<float> SpeedChanged;
        
        [field: SerializeField] public float Speed { get; private set; }
        
        public PlayerTargetSetter TargetSetter { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

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
            var currentTarget = TargetSetter.CurrentTarget;
            
            transform.LookAt(currentTarget.transform);
            
            if (currentTarget == null)
                return;

            if (TargetSetter.MovesCount <= 0)
            {
                _animator.SetBool(AnimatorParameters.IsWalking, false);
                return;
            }

            if (transform.position == currentTarget.transform.position)
            {
                if (currentTarget.TargetStatus == TargetStatus.ChoosingDirection)
                {
                    _animator.SetBool(AnimatorParameters.IsWalking, false);

                    if (_isWaiting == false) 
                    {
                        _isWaiting = true;
                        Speed = 0;

                        SpeedChanged?.Invoke(Speed);
                    }
                }
                else
                {
                    TargetSetter.SetCurrentTarget(0);
                }
                
                TargetSetter.TryReduceMovesCount();
            }
            
            _animator.SetBool(AnimatorParameters.IsWalking, true);

            Move(transform, Time.deltaTime);
        }

        public void InitTargetSetter(MoveCube moveCube)
        {
            TargetSetter = new PlayerTargetSetter(_startTarget, moveCube);
        }
        
        public void Move(Transform currentTransform, float deltaTime)
        {
            var targetPosition = TargetSetter.CurrentTarget.transform.position;

            currentTransform.position =
                Vector3.MoveTowards(currentTransform.position, targetPosition, Speed * deltaTime);
        }
        
        public void ResetSpeed()
        {
            Speed = _startSpeed;
            SpeedChanged?.Invoke(Speed);

            _isWaiting = false;
        }
    }
}