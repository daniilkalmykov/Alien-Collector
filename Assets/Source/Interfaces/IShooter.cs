using Blinders;
using UnityEngine;

namespace Interfaces
{
    public interface IShooter
    {
        BulletBlinder BulletBlinder { get; }
        Transform BulletSpawnPoint { get; }
        
        void Shoot(Vector3 target);
    }
}