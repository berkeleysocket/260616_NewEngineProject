using Scripts.Core.Utilities.SO;
using GameModules.InputActions;

using UnityEngine.InputSystem;

namespace Scripts.Core.InputSystem
{
    public abstract class InputReaderBaseSO : DescriptionSO
    {
        public abstract void Initialize(CharacterInputActions inputActions);
        public abstract void Enable();
        public abstract void Disable();
        public abstract InputActionMap GetInputActionMap();
    }
}