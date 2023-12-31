using Blinders;
using Player;
using UI.Buttons;
using UI.Views;
using UnityEngine;

namespace GameLogic
{
    public sealed class MovementMapBootstrap : MonoBehaviour
    {
        [SerializeField] private MoveCubeBlinder _moveCubeBlinder;
        [SerializeField] private MovesCountsView _movesCountsView;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ThrowingMoveCubeButton _throwingMoveCubeButton;

        private void Awake()
        {
            _moveCubeBlinder.Init();
            _movesCountsView.Init(_moveCubeBlinder);
            _throwingMoveCubeButton.Init(_moveCubeBlinder);
            _playerMovement.InitTargetSetter(_moveCubeBlinder.MoveCube);
        }
    }
}