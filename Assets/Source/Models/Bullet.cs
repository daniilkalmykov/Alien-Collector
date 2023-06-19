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

        public float Speed { get; }
        
        public void Move(Transform currentTransform, float deltaTime)
        {
            const float YPosition = 2;
            var target = new Vector3(_target.x, YPosition, _target.z);

            currentTransform.position = Vector3.MoveTowards(currentTransform.position, target, Speed * Time.deltaTime);
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