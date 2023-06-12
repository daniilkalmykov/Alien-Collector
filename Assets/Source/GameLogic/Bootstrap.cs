using Blinders;
using Models;
using Player;
using UI.Buttons;
using UI.Views;
using UnityEngine;

namespace GameLogic
{
    public sealed class Bootstrap : MonoBehaviour
    {
        [SerializeField] private MoveCubeBlinder _moveCubeBlinder;
        [SerializeField] private MovesCountsView _movesCountsView;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ThrowingMoveCubeButton _throwingMoveCubeButton;

        private void Awake()
        {
            _moveCubeBlinder.Init();
            _movesCountsView.Init(_moveCubeBlinder);
            _playerMovement.Init(_moveCubeBlinder);
            _throwingMoveCubeButton.Init(_moveCubeBlinder);
        }
    }
}