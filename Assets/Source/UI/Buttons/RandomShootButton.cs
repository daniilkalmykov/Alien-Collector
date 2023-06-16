using GameLogic;
using Player;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class RandomShootButton : GameButton
    {
        [SerializeField] private PlayerShooter _playerShooter;
        [SerializeField] private ShootersDistributor _shootersDistributor;

        protected override void OnEnable()
        {
            base.OnEnable();
            _shootersDistributor.PlayerPrepared += OnPlayerPrepared;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _shootersDistributor.PlayerPrepared -= OnPlayerPrepared;
        }

        protected override void OnClick()
        {
            Shoot();
            Button.interactable = false;
        }

        private void OnPlayerPrepared()
        {
            Button.interactable = true;
        }

        private void Shoot()
        {
            _playerShooter.Shoot(_shootersDistributor.GetRandomEnemy().transform.position);
        }
    }
}