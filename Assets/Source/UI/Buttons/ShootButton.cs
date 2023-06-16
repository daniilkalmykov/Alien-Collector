using GameLogic;
using Interfaces;
using UnityEngine;

namespace UI.Buttons
{
    public abstract class ShootButton : GameButton
    {
        [SerializeField] private ShootButton _shootButton;
        
        [field: SerializeField] public ShootersDistributor ShootersDistributor { get; private set; }
        
        protected IPlayerShooter PlayerShooter { get; private set; }

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

        private void OnPlayerPrepared(IPlayerShooter playerShooter)
        {
            PlayerShooter = playerShooter;
            
            Button.interactable = true;
            _shootButton.Button.interactable = true;
        }

        protected abstract void Shoot();
    }
}