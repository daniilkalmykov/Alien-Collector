using Interfaces;
using Models;
using UnityEngine;

namespace Blinders
{
    public sealed class HealthBlinder : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;

        public IHealth Health { get; private set; }

        private void Awake()
        {
            Health = new Health(_maxHealth);
        }
    }
}