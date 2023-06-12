using Blinders;
using TMPro;
using UnityEngine;

namespace UI.Views
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class MovesCountsView : MonoBehaviour
    {
        [SerializeField] private MovesCountBlinder _movesCountBlinder; 
            
        private TMP_Text _movesCount;

        private void Awake()
        {
            _movesCount = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            _movesCountBlinder.MoveCube.MovesCountSet += OnMovesCountSet;
        }

        private void OnDisable()
        {
            _movesCountBlinder.MoveCube.MovesCountSet -= OnMovesCountSet;
        }

        private void OnMovesCountSet(int movesCount)
        {
            _movesCount.text = movesCount.ToString();
        }
    }
}