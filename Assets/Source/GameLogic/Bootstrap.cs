using Blinders;
using UnityEngine;

namespace GameLogic
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private MovesCountBlinder _movesCountBlinder;

        private void Awake()
        {
            _movesCountBlinder.Init();
        }
    }
}