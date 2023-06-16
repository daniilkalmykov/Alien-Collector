using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                shooter.Shot += OnShot;
        }

        private void OnDisable()
        {
            foreach (var shooter in _shooters)
                shooter.Shot -= OnShot;
        }

        private void Start()
        {
            PlayerPrepared?.Invoke(GetRandomPlayer());
        }

        public EnemyShooter GetRandomEnemy()
        {
            return (EnemyShooter)GetRandomShooter(_enemyShooters);
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
            list.AddRange(_shooters.OfType<T>());
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

            _enemyShooters[0].Shoot(GetRandomPlayer().transform.position);
        }

        private PlayerShooter GetRandomPlayer()
        {
            return (PlayerShooter)GetRandomShooter(_playerShooters);
        }
    }
}