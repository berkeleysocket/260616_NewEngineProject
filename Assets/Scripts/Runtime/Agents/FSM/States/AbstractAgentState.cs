using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

namespace Scripts.Runtime.Agents.FSM.States
{
    public abstract class AbstractAgentState
    {
        protected Agent agent;
        private IRenderer _renderer;
        private int _stateAnimationHash;
        private StatePath[] _paths;

        public AbstractAgentState(Agent agent, IRenderer renderer, int stateAnimationHash, StatePath[] paths)
        {
            this.agent = agent;
            this._renderer = renderer;
            this._stateAnimationHash = stateAnimationHash;
            this._paths = paths;
        }

        public void Initialize()
        {
            foreach (StatePath path in _paths)
                path.Condition.Initialize(agent);
        }

        public virtual void Enter(float transitionDuration)
        {
            _renderer.PlayClip(_stateAnimationHash, transitionDuration);
            OnEnter();
        }
        protected abstract void OnEnter();

        public void Update()
        {
            foreach(StatePath path in _paths)
                if (path.Condition.CheckCondition())
                    agent.StateMachine.ChangeState(path.DestinationState);

            OnUpdate();
        }
        protected abstract void OnUpdate();

        public void Exit()
        {
            OnExit();
        }
        protected abstract void OnExit();
    }
}