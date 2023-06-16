using System;

namespace Interfaces
{
    public interface IHealth
    {
        event Action Changed;
        event Action Died;
        
        int CurrentHealth { get; }
        int MaxHealth { get; }

        void TryTakeDamage(int damage);
    }
}