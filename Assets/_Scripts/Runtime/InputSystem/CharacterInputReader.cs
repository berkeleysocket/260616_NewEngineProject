using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using GameModules.InputActions;
using Runtime.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    [CreateAssetMenu(fileName = "CharacterInputReader", menuName = "InputReader/CharacterInputReader")]
    public class CharacterInputReader : InputReaderBaseSO, CharacterInputActions.IPlayerActions
    {
        [Header("Publish Channels")]
        [SerializeField] private GameEventChannelSO playerMoveKeyInputChannel;
        [SerializeField] private GameEventChannelSO playerDashKeyInputChannel;
        [SerializeField] private GameEventChannelSO playerDashAttackKeyInputChannel;

        private CharacterInputActions _inputActions;
        private MoveKeyInputEvent _playerMoveKeyInputEvent;
        private DashKeyInputEvent _playerDashKeyInputEvent;
        private DashAttackKeyInputEvent _playerDashAttackKeyInputEvent;

        public override void Initialize(CharacterInputActions inputActions)
        {
            this._inputActions = inputActions;
            this._playerMoveKeyInputEvent = new MoveKeyInputEvent();
            this._playerDashKeyInputEvent = new DashKeyInputEvent();
            this._playerDashAttackKeyInputEvent = new DashAttackKeyInputEvent();

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
        
        public void OnDashRoll(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DebugLogger.Log("OnDashRoll", Color.violet);
                playerDashKeyInputChannel.RaiseEvent(_playerDashKeyInputEvent);
            }
        }

        public void OnDashAttack(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DebugLogger.Log("OnDashAttack", Color.violet);
                playerDashAttackKeyInputChannel.RaiseEvent(_playerDashAttackKeyInputEvent);
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