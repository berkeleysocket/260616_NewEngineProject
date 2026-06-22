using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsDashingConditionSO", menuName = "SO/StateConditionSO/IsDashingCondition", order = 0)]
    public class IsDashingConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private GameEventChannelSO playerDoActionChannel;
        private bool isDashing = false;

        public override void Initialize(Agent agent)
        {
            playerDoActionChannel.AddListener<IsDashingEvent>(OnDashed);
        }

        public override bool CheckCondition()
        {
            if (isDashing)
            {
                isDashing = false;
                return true;
            }

            return false;
        }

        private void OnDashed(IsDashingEvent args) => isDashing = true;
    }
}
