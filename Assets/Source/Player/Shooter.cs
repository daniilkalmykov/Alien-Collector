using Blinders;
using Interfaces;
using UnityEngine;

namespace Player
{
    public sealed class Shooter : MonoBehaviour, IShooter
    {
        [field: SerializeField] public BulletBlinder BulletBlinder { get; private set; }
        [field: SerializeField] public Transform BulletSpawnPoint { get; private set; }

        public void Shoot(Vector3 target)
        {
            var bulletBlinder = Instantiate(BulletBlinder, BulletSpawnPoint.position, Quaternion.identity);
            bulletBlinder.Init(target);
        }
    }
}