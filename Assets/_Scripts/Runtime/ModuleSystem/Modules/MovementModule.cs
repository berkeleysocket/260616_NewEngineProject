using UnityEngine;
using Utilities;

namespace ModuleSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementModule : MonoBehaviour, IModule
    {
        private ModuleOwner _owner;
        private CharacterController _controller;
        public void Initialize(ModuleOwner owner)
        {
            this._owner = owner;
            this._controller = GetComponent<CharacterController>();

            DebugLogger.ValidateObject(_owner);
            DebugLogger.ValidateObject(_controller);
        }
    }
}

