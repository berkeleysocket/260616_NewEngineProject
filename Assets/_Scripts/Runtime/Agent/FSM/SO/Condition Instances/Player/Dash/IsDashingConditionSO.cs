using Core.Utilities.EventChannelSystem;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "IsDashingCondition", menuName = "SO/StateConditionSO/IsDashingConditionSO", order = 0)]
    public class IsDashingConditionSO : StateConditionSO
    {
        [Header("Subscribe Channels")]
        [SerializeField] private GameEventChannelSO playerIsDashingEvent;
        private bool isDashing = false;

        public override void Initialize(Agent agent)
        {
            playerIsDashingEvent.AddListener<IsDashingEvent>(OnDashed);
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
