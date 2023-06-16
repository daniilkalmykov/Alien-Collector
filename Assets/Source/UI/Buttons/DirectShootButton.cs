using Blinders;
using Models;
using Player;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class DirectShootButton : ShootButton
    {
        [SerializeField] private PlayerInitializer _playerInitializer;
        
        private bool _canShoot;

        private void Update()
        {
            if (_canShoot == false)
                return;
            
            if (Input.touchCount != 1)
                return;

            foreach (var touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Began)
                    return;

                if (_playerInitializer.RaycastCreator.TryCreate(touch.position, out var hit) == false)
                    return;

                if (hit.transform.TryGetComponent(out HealthBlinder _) == false)
                    return;
                
                PlayerShooter.Shoot(hit.transform.position);
                _canShoot = false;
            }
        }

        protected override void Shoot()
        {
            _canShoot = true;
        }
    }
}