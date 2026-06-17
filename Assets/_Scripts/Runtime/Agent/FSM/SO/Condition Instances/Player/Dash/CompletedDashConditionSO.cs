using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "CompletedDashConditionSO", menuName = "SO/StateConditionSO/CompletedDashConditionSO", order = 0)]
    public class CompletedDashConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private GameEventChannelSO completedDashChannel;
        private bool isCompleted = false;

        public override void Initialize(Agent agent)
        {
            completedDashChannel.AddListener<CompletedDashEvent>(OnDashCompleted);
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

        private void OnDashCompleted(CompletedDashEvent args)
        {
            DebugLogger.Log("OnDashCompleted", Color.cyan);
            isCompleted = true;
        }
    }
}