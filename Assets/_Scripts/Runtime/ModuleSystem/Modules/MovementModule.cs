using Core.Utilities;

using UnityEngine;

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

        private void Move(Vector2 direction)
        {
            _controller.Move(new Vector3(direction.x, transform.position.y, direction.y));
        }
    }
}

