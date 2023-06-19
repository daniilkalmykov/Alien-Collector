using Blinders;
using Constants;
using GameLogic;
using Interfaces;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Shooter), typeof(Animator), typeof(HealthBlinder))]
    public sealed class CharacterView : MonoBehaviour
    {
        private IShooter _shooter;
        private HealthBlinder _healthBlinder;
        private Animator _animator;
        private IHealth _health;

        private void Awake()
        {
            _healthBlinder = GetComponent<HealthBlinder>();
            _animator = GetComponent<Animator>();
            _shooter = GetComponent<Shooter>();
        }

        private void OnEnable()
        {
            _shooter.Shot += OnShot;
        }

        private void OnDisable()
        {
            _shooter.Shot -= OnShot;
            _health.Changed -= OnChanged;
        }

        private void Start()
        {
            _health = _healthBlinder.Health;
            
            _health.Changed += OnChanged;
        }

        private void OnChanged()
        {
            _animator.SetTrigger(AnimatorParameters.Hit);
        }

        private void OnShot(IShooter shooter)
        {
            transform.LookAt(shooter.Target);
            _animator.SetTrigger(AnimatorParameters.Shoot);
        }
    }
}