using Runtime.Agents.ModuleSystem.Interface;
using UnityEditor.ShaderGraph;

namespace Runtime.Agents.FSM
{
    public abstract class AbstractState
    {
        protected Agent agent;
        private IRenderer _renderer;
        private int _stateAnimationHash;

        public AbstractState(Agent agent, IRenderer renderer, int stateAnimationHash)
        {
            this.agent = agent;
            this._renderer = renderer;
            this._stateAnimationHash = stateAnimationHash;
        }

        public void Enter()
        {
            _renderer.PlayClip(_stateAnimationHash, 0, 0f);
            OnEnter();
        }
        public abstract void OnEnter();

        public void Update()
        {
            OnUpdate();
        }
        public abstract void OnUpdate();

        public void Exit()
        {
            OnExit();
        }
        public abstract void OnExit();
    }
}

