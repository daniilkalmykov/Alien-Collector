using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Blinders;
using Enemy;
using Interfaces;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public sealed class ShootersDistributor : MonoBehaviour
    {
        [SerializeField] private List<Shooter> _shooters;
        [SerializeField] private float _delay;
        
        private readonly List<IEnemyShooter> _enemyShooters = new();
        private readonly List<IPlayerShooter> _playerShooters = new();
        
        public event Action<IPlayerShooter> PlayerPrepared;

        private void Awake()
        {
            FillShooters(_playerShooters);
            FillShooters(_enemyShooters);
        }

        private void OnEnable()
        {
            foreach (var shooter in _shooters)
            {
                if (shooter.TryGetComponent(out HealthBlinder healthBlinder) == false)
                    throw new ArgumentNullException();
                
                shooter.Shot += OnShot;
                healthBlinder.Health.Died += OnDied;
            }
        }

        private void OnDisable()
        {
            foreach (var shooter in _shooters)
            {
                if (shooter.TryGetComponent(out HealthBlinder healthBlinder) == false) 
                    throw new ArgumentNullException();
                
                shooter.Shot -= OnShot;
                healthBlinder.Health.Died -= OnDied;
            }
        }

        private void Start()
        {
            PlayerPrepared?.Invoke(GetRandomPlayer());
        }

        public EnemyShooter GetRandomEnemy()
        {
            return (EnemyShooter)GetRandomShooter(_enemyShooters);
        }

        private void OnDied()
        {
            RemoveDeadShooter();
        }

        private void RemoveDeadShooter()
        {
            var deadShooter = _shooters.FirstOrDefault(shooter => shooter.gameObject.activeSelf == false);

            switch (deadShooter)
            {
                case PlayerShooter playerShooter:
                    _playerShooters.Remove(playerShooter);
                    break;

                case EnemyShooter enemyShooter:
                    _enemyShooters.Remove(enemyShooter);
                    break;

                default:
                    throw new ArgumentNullException();
            }
        }

        private IShooter GetRandomShooter<T>(List<T> list)
        {
            if (list.Count == 0)
                FillShooters(list);

            return (IShooter)list[Random.Range(0, list.Count)];
        }
        
        private void OnShot(IShooter shooter)
        {
            if (shooter is IPlayerShooter playerShooter)
            {
                _playerShooters.Remove(playerShooter);
                SetNextEnemyShooter();
                return;
            }

            _enemyShooters.Remove((IEnemyShooter)shooter);

            if (_playerShooters.Count == 0)
                FillShooters(_playerShooters);
            
            PlayerPrepared?.Invoke(GetRandomPlayer());
        }

        private void FillShooters<T>(List<T> list)
        {
            var shooters = _shooters.Where(shooter => shooter.gameObject.activeSelf).OfType<T>().ToList();

            if (shooters.Count == 0)
                return;
            
            list.AddRange(shooters);
        }

        private void SetNextEnemyShooter()
        {
            StartCoroutine(WaitToSetNextEnemyShooter());
        }

        private IEnumerator WaitToSetNextEnemyShooter()
        {
            yield return new WaitForSeconds(_delay);
            
            if (_enemyShooters.Count == 0)
                FillShooters(_enemyShooters);

            if (_enemyShooters.Count == 0)
                yield break;
            
            _enemyShooters[0].Shoot(GetRandomPlayer().transform.position);
        }

        private PlayerShooter GetRandomPlayer()
        {
            return (PlayerShooter)GetRandomShooter(_playerShooters);
        }
    }
}