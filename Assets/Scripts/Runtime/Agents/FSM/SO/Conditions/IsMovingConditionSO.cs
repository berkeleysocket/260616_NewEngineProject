using Scripts.Core.Utilities;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO.Conditions
{
    [CreateAssetMenu(fileName = "IsMovingConditionSO", menuName = "SO/StateCondition/IsMovingCondition", order = 0)]
    public class IsMovingConditionSO : StateConditionSO
    {
        private ITriggerModule _triggerModule;
        private bool _moved;

        public override void Initialize(Agent agent)
        {
            this._triggerModule = agent.GetModule<ITriggerModule>();

            DebugLogger.Assert(_triggerModule != null, "triggerModule is null");

            _triggerModule.Moved += () => _moved = true;
        }

        public override bool CheckCondition()
        {
            if(_moved)
            {
                _moved = false;
                return true;
            }
            return false;
        }
    }
}
