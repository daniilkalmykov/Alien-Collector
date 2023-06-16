using Interfaces;
using UnityEngine;

namespace Models
{
    public sealed class Bullet : IMoveable, IUpdatable, IDamageCauser
    {
        private readonly int _damage;
        private readonly Vector3 _target;
        private readonly Transform _transform;

        public Bullet(int damage, Vector3 target, Transform transform, float speed)
        {
            _damage = damage;
            _target = target;
            _transform = transform;
            Speed = speed;
        }

        public float Speed { get; private set; }
        
        public void Move(Transform currentTransform, float deltaTime)
        {
            currentTransform.position =
                Vector3.MoveTowards(currentTransform.position, _target, Speed * Time.deltaTime);
        }

        public void Update(float deltaTime)
        {
            Move(_transform, deltaTime);
        }

        public void Cause(IHealth health)
        {
            health.TryTakeDamage(_damage);
        }
    }
}