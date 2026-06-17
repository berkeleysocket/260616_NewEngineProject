using Core.Utilities;
using GameModules.InputActions;

using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    public abstract class InputReaderBaseSO : DescriptionSO
    {
        public abstract void Initialize(CharacterInputActions inputActions);
        public abstract void Enable();
        public abstract void Disable();
        public abstract InputActionMap GetInputActionMap();
    }
}