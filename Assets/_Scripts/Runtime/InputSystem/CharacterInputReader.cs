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
        [SerializeField] private GameEventChannelSO playerMoveKeyInputChannel;
        [SerializeField] private GameEventChannelSO playerDashKeyInputChannel;

        private PlayerMoveKeyInputEvent _playerMoveKeyInputEvent;
        private PlayerDashKeyInputEvent _playerDashKeyInputEvent;
        private CharacterInputActions _inputActions;

        public override void Initialize(CharacterInputActions inputActions)
        {
            this._inputActions = inputActions;
            this._playerMoveKeyInputEvent = new PlayerMoveKeyInputEvent();
            this._playerDashKeyInputEvent = new PlayerDashKeyInputEvent();

            DebugLogger.Assert(playerMoveKeyInputChannel != null, "PlayerMoveKeyInputChannel is null");
            DebugLogger.Assert(playerDashKeyInputChannel != null, "PlayerDashKeyInputChannel is null");
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
                playerDashKeyInputChannel.RaiseEvent(_playerDashKeyInputEvent);
            }
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Vector2 direction = context.ReadValue<Vector2>();

                _playerMoveKeyInputEvent.direction = direction;
                playerMoveKeyInputChannel.RaiseEvent(_playerMoveKeyInputEvent);
            }
        }
    }
}