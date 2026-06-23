using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "CompletedDashConditionSO", menuName = "SO/StateConditionSO/CompletedDashCondition", order = 0)]
    public class CompletedDashConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private EventChannelSO playerCompletedActionChannel;
        private bool isCompleted = false;

        public override void Initialize(Agent agent)
        {
            playerCompletedActionChannel.AddListener<CompletedDashEvent>(OnDashCompleted);
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

        private void OnDashCompleted(CompletedDashEvent args) => isCompleted = true;
    }
}