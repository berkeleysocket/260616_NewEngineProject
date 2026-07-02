using Runtime.Agents.ModuleSystem;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.Interface
{
    public interface IMovementModule : IModule
    {
        bool CanMove { get; set; }
        Vector2 LastMoveDirection { get; }

        void Move(Vector2 direction);
        void RotateTo(Vector3 direction);
        void SetVelocity(float speed);
    }
}