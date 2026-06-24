using Scripts.Core.Utilities;
using Scripts.Runtime.Agents.ModuleSystem.Modules;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO.Conditions
{
    [CreateAssetMenu(fileName = "IsMovingConditionSO", menuName = "SO/StateCondition/IsMovingCondition", order = 0)]
    public class IsMovingConditionSO : StateConditionSO
    {
        private IMovable _movement;

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

