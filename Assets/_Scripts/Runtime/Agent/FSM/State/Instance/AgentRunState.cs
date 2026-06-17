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
            DebugLogger.Log("Enter Run State");
        }

        protected override void OnExit()
        {
            DebugLogger.Log("Exit Run State");
        }

        protected override void OnUpdate()
        {

        }
    }
}