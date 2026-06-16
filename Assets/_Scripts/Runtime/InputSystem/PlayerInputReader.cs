using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using GameModules.InputActions;
using Runtime.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    [CreateAssetMenu(fileName = "PlayerInputReader", menuName = "InputReader/PlayerInputReader")]
    public class PlayerInputReader : InputReaderBaseSO, CharacterInputActions.IPlayerActions
    {
        [SerializeField] private GameEventChannelSO playerMoveInputChannel;

        private PlayerMoveInputEvent _playerMoveInputEvent;
        private CharacterInputActions _inputActions;

        public override void Initialize(CharacterInputActions inputActions)
        {
            this._inputActions = inputActions;
            this._playerMoveInputEvent = new PlayerMoveInputEvent();

            DebugLogger.ValidateObject(playerMoveInputChannel);
        }

        public override void Enable()
        {
            if (_inputActions != null)
            {
                _inputActions.Player.AddCallbacks(this);
                _inputActions.Enable();
            }
        }

        public override void Disable()
        {
            if(_inputActions != null)
            {
                _inputActions.Player.RemoveCallbacks(this);
                _inputActions.Disable();
            }
        }

        public override InputActionMap GetInputActionMap() => _inputActions?.Player;
        
        public void OnJump(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Vector2 direction = context.ReadValue<Vector2>();

                _playerMoveInputEvent.direction = direction;
                playerMoveInputChannel.RaiseEvent(_playerMoveInputEvent);
            }
            else if(context.canceled)
            {
                _playerMoveInputEvent.direction = Vector2.zero;
                playerMoveInputChannel.RaiseEvent(_playerMoveInputEvent);
            }
        }
    }
}