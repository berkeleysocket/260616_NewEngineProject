using Runtime.Agents.ModuleSystem;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsAttackingConditionSO", menuName = "SO/StateConditionSO/IsAttackingCondition")]
    public class IsAttackingConditionSO : StateConditionSO
    {
        private bool isAttacking;

        public override void Initialize(Agent agent)
        {
            AbstractAttackModule attackModule = agent.GetModule<AbstractAttackModule>();
            if (attackModule != null)
                attackModule.isAttacking += () => isAttacking = true;
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
