using Core.Utilities;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.FSM
{
    public class AgentAttackState : AbstractAgentState
    {
        private AbstractAttackModule _attackModule;

        public AgentAttackState(Agent agent, IRenderer renderer, int stateAnimationHash, StateConditionSO[] conditions)
            : base(agent, renderer, stateAnimationHash, conditions)
        {
            _attackModule = agent.GetModule<AbstractAttackModule>();
        }

        protected override void OnEnter()
        {
            DebugLogger.Log("Enemy is Attacking!");
            _attackModule.Attack();
        }

        protected override void OnExit()
        {
        }

        protected override void OnUpdate()
        {

        }
    }
}