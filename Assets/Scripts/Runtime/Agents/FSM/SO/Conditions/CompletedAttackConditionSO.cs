using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO.Conditions
{
    [CreateAssetMenu(fileName = "CompletedAttackConditionSO", menuName = "SO/StateCondition/CompletedAttackCondition")]
    public class CompletedAttackConditionSO : StateConditionSO
    {
        public override void Initialize(Agent agent)
        {

        }

        public override bool CheckCondition()
        {
            return false;
        }
    }
}