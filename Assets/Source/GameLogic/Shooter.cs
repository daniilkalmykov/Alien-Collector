using System;
using System.Collections;
using Blinders;
using Interfaces;
using UnityEngine;

namespace GameLogic
{
    public abstract class Shooter : MonoBehaviour, IShooter
    {
        public event Action<IShooter> Shot;

        [field: SerializeField] public BulletBlinder BulletBlinder { get; private set; }
        [field: SerializeField] public Transform BulletSpawnPoint { get; private set; }
        
        public Vector3 Target { get; private set; }

        public void Shoot(Vector3 target)
        {
            Target = target;
            
            Shot?.Invoke(this);
        }

        public void SpawnBullet()
        {
            var bulletBlinder = Instantiate(BulletBlinder, BulletSpawnPoint.position, Quaternion.identity);
            bulletBlinder.Init(Target);
        }
    }
}