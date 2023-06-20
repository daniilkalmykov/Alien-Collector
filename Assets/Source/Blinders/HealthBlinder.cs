using Interfaces;
using Models;
using UI.Bars;
using UnityEngine;

namespace Blinders
{
    public sealed class HealthBlinder : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private HealthBar _healthBar;

        public IHealth Health { get; private set; }

        public void Init()
        {
            Health = new Health(_maxHealth);
            
            _healthBar.Init(Health);
        }
    }
}