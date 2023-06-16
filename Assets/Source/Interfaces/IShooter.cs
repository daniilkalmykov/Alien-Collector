using System;
using Blinders;
using UnityEngine;

namespace Interfaces
{
    public interface IShooter
    {
        BulletBlinder BulletBlinder { get; }
        Transform BulletSpawnPoint { get; }

        event Action<IShooter> Shot;
        
        void Shoot(Vector3 target);
    }
}