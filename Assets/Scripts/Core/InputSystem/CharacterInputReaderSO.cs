using Scripts.Core.EventChannels;
using Scripts.Core.Utilities;
using Scripts.Core.EventChannels.SO;
using GameModules.InputActions;

using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.Core.InputSystem
{
    [CreateAssetMenu(fileName = "CharacterInputReader", menuName = "SO/InputReader/CharacterInputReaderSO")]
    public class CharacterInputReaderSO : InputReaderBaseSO, CharacterInputActions.IPlayerActions
    {
        [Header("Publish Channels")]
        [SerializeField] private EventChannelSO pressKeyChannel;

        private CharacterInputActions _inputActions;
        private MoveKeyInputEvent _playerMoveKeyInputEvent;
        private ActiveSkillKeyInputEvent _activeSkill01KeyInputEvent;
        private ActiveSkillKeyInputEvent _activeSkill02KeyInputEvent;
        private ActiveSkillKeyInputEvent _activeSkill03KeyInputEvent;

        public override void Initialize(CharacterInputActions inputActions)
        {
            this._inputActions = inputActions;
            this._playerMoveKeyInputEvent = new MoveKeyInputEvent();
            this._activeSkill01KeyInputEvent = new ActiveSkillKeyInputEvent();
            this._activeSkill02KeyInputEvent = new ActiveSkillKeyInputEvent();
            this._activeSkill03KeyInputEvent = new ActiveSkillKeyInputEvent();

            DebugLogger.Assert(pressKeyChannel != null, "PressKeyChannel is null");
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
        
        public void OnDashAttack(InputAction.CallbackContext context)
        {

        }

        public void OnMove(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Vector2 direction = context.ReadValue<Vector2>();

                _playerMoveKeyInputEvent.Direction = direction;
                pressKeyChannel.RaiseEvent(_playerMoveKeyInputEvent);
            }
        }

        public void OnActiveSkill(InputAction.CallbackContext context)
        {
            if (context.started)
                pressKeyChannel.RaiseEvent(_activeSkill01KeyInputEvent);
        }

        public void OnActiveSkill01(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnActiveSkill02(InputAction.CallbackContext context)
        {
            if (context.started)
                pressKeyChannel.RaiseEvent(_activeSkill02KeyInputEvent);
        }

        public void OnActiveSkill03(InputAction.CallbackContext context)
        {
            if (context.started)
                pressKeyChannel.RaiseEvent(_activeSkill03KeyInputEvent);
        }
    }
}