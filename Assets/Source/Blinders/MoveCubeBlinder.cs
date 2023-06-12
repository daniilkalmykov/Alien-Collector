using Models;
using UnityEngine;

namespace Blinders
{
    public sealed class MoveCubeBlinder : MonoBehaviour
    {
        public MoveCube MoveCube { get; private set; }

        public void Init()
        {
            MoveCube = new MoveCube();
        }
    }
}