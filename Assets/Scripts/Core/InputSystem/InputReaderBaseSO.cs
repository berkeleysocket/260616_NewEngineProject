using GameModules.InputActions;

using UnityEngine.InputSystem;
using UnityEngine;

namespace Scripts.Core.InputSystem
{
    public abstract class InputReaderBaseSO : ScriptableObject
    {
        public abstract void Initialize(CharacterInputActions inputActions);
        public abstract void Enable();
        public abstract void Disable();
        public abstract InputActionMap GetInputActionMap();
    }
}