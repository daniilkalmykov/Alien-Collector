using Blinders;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(BulletBlinder))]
    public sealed class BulletCollisionsHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _hit;
        
        private BulletBlinder _bulletBlinder;

        private void Awake()
        {
            _bulletBlinder = GetComponent<BulletBlinder>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out HealthBlinder healthBlinder))
            {
                Instantiate(_hit, transform.position, Quaternion.identity, null);
                _bulletBlinder.DamageCauser.Cause(healthBlinder.Health);
            }
            
            Destroy(gameObject);
        }
    }
}