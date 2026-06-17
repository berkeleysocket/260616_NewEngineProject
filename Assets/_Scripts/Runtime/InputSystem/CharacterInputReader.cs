using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using GameModules.Input;
using Runtime.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    [CreateAssetMenu(fileName = "CharacterInputReader", menuName = "InputReader/CharacterInputReader")]
    public class CharacterInputReader : InputReaderBaseSO, CharacterInputActions.IPlayerActions
    {
        [SerializeField] private GameEventChannelSO playerMoveInputChannel;
        [SerializeField] private GameEventChannelSO playerDashInputChannel;

        private PlayerMoveInputEvent _playerMoveInputEvent;
        private PlayerDashInputEvent _playerDashInputEvent;
        private CharacterInputActions _inputActions;

        public override void Initialize(CharacterInputActions inputActions)
        {
            this._inputActions = inputActions;
            this._playerMoveInputEvent = new PlayerMoveInputEvent();
            this._playerDashInputEvent = new PlayerDashInputEvent();

            DebugLogger.Assert(playerMoveInputChannel != null, "PlayerMoveInputChannel is null");
            DebugLogger.Assert(playerDashInputChannel != null, "playerDashInputChannel is null");
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
        
        public void OnDash(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                playerDashInputChannel.RaiseEvent(_playerDashInputEvent);
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
        }
    }
}