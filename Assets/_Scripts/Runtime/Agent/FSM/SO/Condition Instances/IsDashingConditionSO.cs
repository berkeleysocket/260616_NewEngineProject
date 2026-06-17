using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsDashingConditionSO", menuName = "SO/StateConditionSO/IsDashingConditionSO", order = 0)]
    public class IsDashingConditionSO : StateConditionSO
    {
        [SerializeField] private GameEventChannelSO playerInputDashChannel;
        private bool isDashing = true;
        public override void Initialize(Agent agent)
        {
            playerInputDashChannel.AddListener<PlayerDashInputEvent>(OnPlayerDashed);
        }

        public override bool CheckCondition()
        {
            DebugLogger.Log("Check Condition");
            if (isDashing)
            {
                isDashing = false;
                return true;
            }

            return false;
        }

        private void OnPlayerDashed(PlayerDashInputEvent args)
        {
            DebugLogger.Log("OnPlayerDashed");
            isDashing = true;
        }
    }
}
