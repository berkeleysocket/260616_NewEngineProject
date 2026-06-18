using Core.Utilities;
using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.FSM
{
    public class AgentDashAttackState : AbstractAgentState
    {
        public AgentDashAttackState(Agent agent, IRenderer renderer, int stateAnimationHash, StateConditionSO[] conditions)
            : base(agent, renderer, stateAnimationHash, conditions)
        {
        }

        protected override void OnEnter()
        {
        }

        protected override void OnExit()
        {
        }

        protected override void OnUpdate()
        {

        }
    }
}