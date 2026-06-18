using Core.Utilities;
using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.FSM
{
    public class AgentRunState : AbstractAgentState
    {
        public AgentRunState(Agent agent, IRenderer renderer, int stateAnimationHash, StateConditionSO[] conditions) 
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