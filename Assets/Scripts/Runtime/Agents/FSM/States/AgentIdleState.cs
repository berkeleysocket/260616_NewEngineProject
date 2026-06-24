using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

namespace Scripts.Runtime.Agents.FSM.States
{
    public class AgentIdleState : AbstractAgentState
    {
        public AgentIdleState(Agent agent, IRenderer renderer, int stateAnimationHash, StatePath[] conditions) 
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