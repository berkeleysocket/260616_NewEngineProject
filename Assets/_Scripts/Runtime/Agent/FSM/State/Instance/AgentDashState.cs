using Core.Utilities;
using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.FSM
{
    public class AgentDashState : AbstractAgentState
    {
        public AgentDashState(Agent agent, IRenderer renderer, int stateAnimationHash, StateConditionSO[] conditions)
            : base(agent, renderer, stateAnimationHash, conditions)
        {
        }

        protected override void OnEnter()
        {
            DebugLogger.Log("Enter Dash State");
        }

        protected override void OnExit()
        {
            DebugLogger.Log("Exit Dash State");
        }

        protected override void OnUpdate()
        {

        }
    }
}