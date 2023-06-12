namespace Interfaces
{
    public interface IMoveable
    {
        float Speed { get; }
        
        void Move(float deltaTime);
    }
}