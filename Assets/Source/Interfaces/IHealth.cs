namespace Interfaces
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }

        void TryTakeDamage(int damage);
    }
}