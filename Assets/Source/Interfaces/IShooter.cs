using System;
using Blinders;
using UnityEngine;

namespace Interfaces
{
    public interface IShooter
    {
        event Action<IShooter> Shot;
        
        BulletBlinder BulletBlinder { get; }
        Transform BulletSpawnPoint { get; }
        Vector3 Target { get; }

        void Shoot(Vector3 target);
    }
}