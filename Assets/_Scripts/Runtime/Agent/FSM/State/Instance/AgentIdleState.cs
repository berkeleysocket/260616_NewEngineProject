using Core.Utilities;
using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.FSM
{
    public class AgentIdleState : AbstractAgentState
    {
        public AgentIdleState(Agent agent, IRenderer renderer, int stateAnimationHash, StateConditionSO[] conditions) 
            : base(agent, renderer, stateAnimationHash, conditions)
        {
        }

        protected override void OnEnter()
        {
            DebugLogger.Log("Enter Idle State");
        }

        protected override void OnExit()
        {
            DebugLogger.Log("Exit Idle State");
        }

        protected override void OnUpdate()
        {

        }
    }
}