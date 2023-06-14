using Player;
using UI.Buttons;
using UnityEngine;

namespace GameLogic
{
    public sealed class PlayerSpeedHandler : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ChoosingDirectionButton[] _choosingDirectionButtons;

        private void OnEnable()
        {
            _playerMovement.SpeedChanged += OnSpeedChanged;
        }

        private void OnDisable()
        {
            _playerMovement.SpeedChanged -= OnSpeedChanged;
        }
        
        private void OnSpeedChanged(float speed)
        {
            print(speed);
            ChangeButtonsVisibility(speed == 0);
        }

        private void ChangeButtonsVisibility(bool isEnabled)
        {
            foreach (var choosingDirectionButton in _choosingDirectionButtons)
                choosingDirectionButton.gameObject.SetActive(isEnabled);
        }
    }
}