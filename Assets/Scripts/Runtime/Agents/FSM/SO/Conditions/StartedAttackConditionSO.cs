using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO.Conditions
{
    [CreateAssetMenu(fileName = "StartedAttackConditionSO", menuName = "SO/StateCondition/StartedAttackCondition")]
    public class StartedAttackConditionSO : StateConditionSO
    {
        private bool isAttacking;

        public override void Initialize(Agent agent)
        {

        }

        public override bool CheckCondition()
        {
            if (isAttacking)
            {
                isAttacking = false;
                return true;
            }

            return false;
        }
    }
}
