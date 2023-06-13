using Player;
using UnityEngine;

namespace UI.Buttons
{
    public sealed class ChoosingDirectionButton : GameButton
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private int _targetId;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        protected override void OnClick()
        {
            _playerMovement.ResetSpeed();
            _playerMovement.TargetSetter.SetCurrentTarget(_targetId);
        }
    }
}