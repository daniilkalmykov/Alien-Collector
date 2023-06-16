using GameLogic;
using Interfaces;
using UnityEngine;

namespace UI.Buttons
{
    public abstract class ShootButton : GameButton
    {
        [SerializeField] private CanvasGroup _background;
        
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
            ChangeVisibility(false);
        }

        private void OnPlayerPrepared(IPlayerShooter playerShooter)
        {
            PlayerShooter = playerShooter;
            ChangeVisibility(true);
        }

        private void ChangeVisibility(bool isEnabled)
        {
            _background.alpha = isEnabled ? 1 : 0;
            _background.interactable = isEnabled;
            _background.blocksRaycasts = isEnabled;
        }
        
        protected abstract void Shoot();
    }
}