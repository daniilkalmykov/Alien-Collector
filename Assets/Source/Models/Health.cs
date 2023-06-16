using System;
using Interfaces;
using UnityEngine;

namespace Models
{
    public sealed class Health : IHealth
    {
        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
        
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }
        
        public void TryTakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentNullException();

            CurrentHealth -= damage;
            Debug.Log(CurrentHealth);
        }
    }
}