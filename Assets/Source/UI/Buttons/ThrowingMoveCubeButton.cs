using Blinders;

namespace UI.Buttons
{
    public sealed class ThrowingMoveCubeButton : GameButton
    {
        private MoveCubeBlinder _moveCubeBlinder;
        
        public void Init(MoveCubeBlinder moveCubeBlinder)
        {
            _moveCubeBlinder = moveCubeBlinder;
        }
        
        protected override void OnClick()
        {
            ThrowCube();
        }

        private void ThrowCube()
        {
            _moveCubeBlinder.MoveCube.Throw();
        }
    }
}