using Blinders;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class MovesCountsView : MonoBehaviour
    {
        private MoveCubeBlinder _moveCubeBlinder; 
        private TMP_Text _movesCount;

        private void Awake()
        {
            _movesCount = GetComponent<TMP_Text>();
        }

        private void OnDisable()
        {
            _moveCubeBlinder.MoveCube.MovesCountSet -= OnMovesCountSet;
        }

        public void Init(MoveCubeBlinder moveCubeBlinder)
        {
            _moveCubeBlinder = moveCubeBlinder;
            
            _moveCubeBlinder.MoveCube.MovesCountSet += OnMovesCountSet;
        }

        private void OnMovesCountSet(int movesCount)
        {
            _movesCount.text = movesCount.ToString();
        }
    }
}