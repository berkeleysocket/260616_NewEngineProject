using Scripts.Core.Utilities;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

namespace Scripts.Runtime.Agents.FSM.States
{
    public class AgentAttackState : AbstractAgentState
    {
        public AgentAttackState(Agent agent, IRenderer renderer, int stateAnimationHash, StatePath[] conditions)
            : base(agent, renderer, stateAnimationHash, conditions)
        {
        }

        protected override void OnEnter()
        {
            DebugLogger.Log("Enemies is Attacking!");
        }

        protected override void OnUpdate()
        {

        }

        protected override void OnExit()
        {
        }
    }
}