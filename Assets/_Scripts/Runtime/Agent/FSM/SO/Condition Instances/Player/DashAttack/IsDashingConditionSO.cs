using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsDashAttackingConditionSO", menuName = "SO/StateConditionSO/IsDashAttackingCondition", order = 0)]
    public class IsDashAttackingConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private EventChannelSO playerDoActionChannel;
        private bool isDashAttacking = false;

        public override void Initialize(Agent agent)
        {
            playerDoActionChannel.AddListener<IsDashAttackingEvent>(OnDashAttacked);
        }

        public override bool CheckCondition()
        {
            if (isDashAttacking)
            {
                isDashAttacking = false;
                return true;
            }

            return false;
        }

        private void OnDashAttacked(IsDashAttackingEvent args) => isDashAttacking = true;
    }
}
