using Core.Utilities;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsMovingCondition", menuName = "SO/StateConditionSO/IsMovingCondition", order = 0)]
    public class IsMovingConditionSO : StateConditionSO
    {
        private IPlayerMovementModule _movement;

        public override void Initialize(Agent agent)
        {
            this._movement = agent.GetModule<MovementModule>();

            DebugLogger.Assert(_movement != null, "Movement is null");
        }

        public override bool CheckCondition()
        {
            if (_movement.IsMoving)
                return true;
            return false;
        }
    }
}

