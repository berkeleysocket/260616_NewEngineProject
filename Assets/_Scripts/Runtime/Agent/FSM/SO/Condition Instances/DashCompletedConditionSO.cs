using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "DashCompletedCondition", menuName = "SO/StateConditionSO/DashCompletedConditionSO", order = 0)]
    public class DashCompletedConditionSO : StateConditionSO
    {
        [SerializeField] private GameEventChannelSO playerCompletedDashChannel;
        private bool isCompleted = true;

        public override void Initialize(Agent agent)
        {
            playerCompletedDashChannel.AddListener<PlayerCompletedDashEvent>(OnDashCompleted);
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

        private void OnDashCompleted(PlayerCompletedDashEvent args) => isCompleted = true;
    }
}
