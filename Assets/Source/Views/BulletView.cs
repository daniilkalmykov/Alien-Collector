using Blinders;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(BulletBlinder))]
    public sealed class BulletView : MonoBehaviour
    {
        private BulletBlinder _bulletBlinder;

        private void Awake()
        {
            _bulletBlinder = GetComponent<BulletBlinder>();
        }

        private void Update()
        {
            _bulletBlinder.Updatable.Update(Time.deltaTime);
        }
    }
}