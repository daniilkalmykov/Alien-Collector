using System;
using GameLogic;
using Player;
using UI.Buttons;
using UnityEngine;

namespace UI
{
    public abstract class ShootButton : GameButton
    {
        [SerializeField] private ShootButton _shootButton;
        
        [field: SerializeField] protected PlayerShooter PlayerShooter { get; private set; }
        [field: SerializeField] public ShootersDistributor ShootersDistributor { get; private set; }

        protected override void OnEnable()
        {
            base.OnEnable();
            ShootersDistributor.PlayerPrepared += OnPlayerPrepared;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            ShootersDistributor.PlayerPrepared -= OnPlayerPrepared;
        }

        protected override void OnClick()
        {
            Shoot();
            
            Button.interactable = false;
            _shootButton.Button.interactable = false;
        }

        private void OnPlayerPrepared()
        {
            Button.interactable = true;
            _shootButton.Button.interactable = true;
        }

        protected abstract void Shoot();
    }
}