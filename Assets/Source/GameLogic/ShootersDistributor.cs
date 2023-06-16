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
        
        private readonly List<IShooter> _enemyShooters = new();
        
        private PlayerShooter _playerShooter;

        public event Action PlayerPrepared;

        private void Awake()
        {
            FillEnemyShooters();

            _playerShooter = (PlayerShooter)_shooters.FirstOrDefault(shooter => shooter is PlayerShooter);
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

        public EnemyShooter GetRandomEnemy()
        {
            if (_enemyShooters.Count == 0)
                FillEnemyShooters();
            
            return (EnemyShooter)_enemyShooters[Random.Range(0, _enemyShooters.Count)];
        }
        
        private void OnShot(IShooter shooter)
        {
            if (shooter is IPlayerShooter)
            {
                SetNextEnemyShooter();
                return;
            }

            _enemyShooters.Remove(shooter);
            PlayerPrepared?.Invoke();
        }

        private void FillEnemyShooters()
        {
            foreach (var shooter in _shooters.OfType<IEnemyShooter>())
                _enemyShooters.Add(shooter);
        }

        private void SetNextEnemyShooter()
        {
            StartCoroutine(WaitToSetNextEnemyShooter());
        }

        private IEnumerator WaitToSetNextEnemyShooter()
        {
            if (_enemyShooters.Count == 0)
                FillEnemyShooters();

            yield return new WaitForSeconds(_delay);
            
            _enemyShooters[0].Shoot(_playerShooter.transform.position);
        }
    }
}