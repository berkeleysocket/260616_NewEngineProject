using Core.Utilities.EventChannelSystem;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsDashAttackingCondition", menuName = "SO/StateConditionSO/IsDashAttackingConditionSO", order = 0)]
    public class IsDashAttackingConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private GameEventChannelSO playerIsDashAttackingEvent;
        private bool isDashAttacking = false;

        public override void Initialize(Agent agent)
        {
            playerIsDashAttackingEvent.AddListener<IsDashAttackingEvent>(OnDashAttacked);
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
