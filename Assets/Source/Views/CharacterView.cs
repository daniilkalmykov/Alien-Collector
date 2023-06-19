using Constants;
using GameLogic;
using Interfaces;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Shooter), typeof(Animator))]
    public sealed class CharacterView : MonoBehaviour
    {
        private IShooter _shooter;
        private Animator _animator;

        private void Awake()
        {
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
        }

        private void OnShot(IShooter shooter)
        {
            transform.LookAt(shooter.Target);
            _animator.SetTrigger(AnimatorParameters.Shoot);
        }
    }
}