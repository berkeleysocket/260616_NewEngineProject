using Core.Utilities;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsStoppingConditionSO", menuName = "SO/StateConditionSO/IsStoppingConditionSO", order = 0)]
    public class IsStoppingConditionSO : StateConditionSO
    {
        private IMovement _movement;
        
        public override void Initialize(Agent agent)
        {
            this._movement = agent.GetModule<MovementModule>();

            DebugLogger.ValidateObject(_movement);
        }
        
        public override bool CheckCondition()
        {
            if (!_movement.IsMoving)
                return true;
            return false;
        }
    }
}
