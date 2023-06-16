using Interfaces;
using Models;
using UnityEngine;

namespace Blinders
{
    public sealed class BulletBlinder : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        
        public IDamageCauser DamageCauser { get; private set; }
        public IUpdatable Updatable { get; private set; }

        public void Init(Vector3 target)
        {
            var bullet = new Bullet(_damage, target, transform, _speed);
            
            DamageCauser = bullet;
            Updatable = bullet;
        }
    }
}