using Runtime.Agnet.ModuleSystem;
using Runtime.Agents.FSM;

namespace Runtime.Agents
{
    public class Player : Agent
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            //_stateMachine.Initialize(GetModule<RendererModule>(), );
        }
    }
}