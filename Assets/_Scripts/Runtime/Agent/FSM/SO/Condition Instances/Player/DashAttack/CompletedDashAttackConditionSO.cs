using Core.Utilities.EventChannelSystem;
using Runtime.Player;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "CompletedDashAttackCondition", menuName = "SO/StateConditionSO/CompletedDashAttackConditionSO", order = 0)]
    public class CompletedDashAttackConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private GameEventChannelSO playerCompletedActionChannel;
        private bool isCompleted = false;

        public override void Initialize(Agent agent)
        {
            playerCompletedActionChannel.AddListener<CompletedDashAttackEvent>(OnCompletedDashAttack);
        }

        public override bool CheckCondition()
        {
            if (isCompleted)
            {
                isCompleted = false;
                return true;
            }

            return false;
        }

        private void OnCompletedDashAttack(CompletedDashAttackEvent args) => isCompleted = true;
    }
}