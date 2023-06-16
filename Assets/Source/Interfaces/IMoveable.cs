using UnityEngine;

namespace Interfaces
{
    public interface IMoveable
    {
        float Speed { get; }
        
        void Move(Transform currentTransform, float deltaTime);
    }
}