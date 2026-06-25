using Scripts.Core.EventChannels;
using Scripts.Core.Utilities;
using Scripts.Core.EventChannels.SO;
using GameModules.InputActions;

using UnityEngine;
using UnityEngine.InputSystem;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;

namespace Scripts.Core.InputSystem
{
    [CreateAssetMenu(fileName = "CharacterInputReader", menuName = "SO/InputReader/CharacterInputReaderSO")]
    public class CharacterInputReaderSO : InputReaderBaseSO, CharacterInputActions.IPlayerActions
    {
        [SerializeField] private EventChannelSO pressKeyChannel;

        private CharacterInputActions _inputActions;

        public override void Initialize(CharacterInputActions inputActions)
        {
            this._inputActions = inputActions;

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

        public void OnMove(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                Vector2 direction = context.ReadValue<Vector2>();
                PlayerEvents.MoveKeyInputEvent.Initialize(direction);
                pressKeyChannel.RaiseEvent(PlayerEvents.MoveKeyInputEvent);
            }
        }

        public void OnActiveSkill01(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PlayerEvents.ActiveSkillKeyInputEvent.Initialize(SkillType.ActiveSkill01);
                pressKeyChannel.RaiseEvent(PlayerEvents.ActiveSkillKeyInputEvent);
            }
        }

        public void OnActiveSkill02(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PlayerEvents.ActiveSkillKeyInputEvent.Initialize(SkillType.ActiveSkill02);
                pressKeyChannel.RaiseEvent(PlayerEvents.ActiveSkillKeyInputEvent);
            }
        }

        public void OnActiveSkill03(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                PlayerEvents.ActiveSkillKeyInputEvent.Initialize(SkillType.ActiveSkill03);
                pressKeyChannel.RaiseEvent(PlayerEvents.ActiveSkillKeyInputEvent);
            }
        }
    }
}