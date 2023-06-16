using System;
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
        
        public void Shoot(Vector3 target)
        {
            var bulletBlinder = Instantiate(BulletBlinder, BulletSpawnPoint.position, Quaternion.identity);
            bulletBlinder.Init(target);

            Shot?.Invoke(this);
        }
    }
}