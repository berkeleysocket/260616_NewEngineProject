using Core.Utilities;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsMovingConditionSO", menuName = "SO/StateConditionSO/IsMovingCondition", order = 0)]
    public class IsMovingConditionSO : StateConditionSO
    {
        private IMovement _movement;

        public override void Initialize(Agent agent)
        {
            this._movement = agent.GetModule<MovementModule>();

            DebugLogger.ValidateObject(_movement);
        }

        public override bool CheckCondition()
        {
            DebugLogger.Log($"CheckCondition - _movement.IsMoving : {_movement.IsMoving}");
            if (_movement.IsMoving)
                return true;
            return false;
        }
    }
}

