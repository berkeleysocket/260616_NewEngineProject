using UnityEngine;

namespace Runtime.Agents.ModuleSystem.Interface
{
    public interface IMovementable
    {

    }

    public interface IEnemyMovementModule
    {

    }

    public interface IPlayerMovementModule
    {
        public bool IsMoving { get; }
        public bool IsDashAttacking { get; }
    }
}

