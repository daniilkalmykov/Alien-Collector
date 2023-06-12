using System;
using Random = UnityEngine.Random;

namespace Models
{
    public sealed class MoveCube
    {
        private const int MinMovesCount = 1;
        private const int MaxMovesCount = 6;

        public event Action<int> MovesCountSet;
        
        public void Throw()
        {
            MovesCountSet?.Invoke(Random.Range(MinMovesCount, MaxMovesCount));
        }
    }
}