using Blinders;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class ThrowingMoveCubeButton : GameButton
    {
        [SerializeField] private MovesCountBlinder _movesCountBlinder;
        
        protected override void OnClick()
        {
            ThrowCube();
        }

        private void ThrowCube()
        {
            _movesCountBlinder.MoveCube.Throw();
        }
    }
}