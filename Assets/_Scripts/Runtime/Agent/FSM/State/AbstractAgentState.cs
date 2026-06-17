using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.FSM
{
    public abstract class AbstractAgentState
    {
        protected Agent agent;
        private IRenderer _renderer;
        private int _stateAnimationHash;
        private StateConditionSO[] _conditions;

        public AbstractAgentState(Agent agent, IRenderer renderer, int stateAnimationHash, StateConditionSO[] conditions)
        {
            this.agent = agent;
            this._renderer = renderer;
            this._stateAnimationHash = stateAnimationHash;
            this._conditions = conditions;
        }

        public void Initialize()
        {
            foreach (StateConditionSO condition in _conditions)
            {
                condition.Initialize(agent);
            }
        }

        public virtual void Enter(float transitionDuration)
        {
            _renderer.PlayClip(_stateAnimationHash, transitionDuration);
            OnEnter();
        }
        protected abstract void OnEnter();

        public void Update()
        {
            foreach(var condition in _conditions)
            {
                if (condition.CheckCondition())
                {
                    agent.StateMachine.ChangeState((byte)condition.NextStateType);
                }
            }
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

