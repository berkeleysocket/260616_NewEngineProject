using Core.Utilities;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;

using System;
using System.Collections.Generic;

namespace Runtime.Agents.FSM
{
    public class StateMachine
    {
        private Dictionary<byte, AbstractAgentState> _states;
        private AbstractAgentState _currentState;

        public void Initialize(Agent agent, AgentStateSO[] stateList)
        {
            this._states = new Dictionary<byte, AbstractAgentState>();

            foreach (AgentStateSO stateSO in stateList)
            {
                Type stateType = Type.GetType(stateSO.ClassName);
                IRenderer renderer = agent.GetModule<RendererModule>();
                int animationHash = stateSO.AnimationParamSO.ClipHash;
                StateConditionSO[] conditions = stateSO.Conditions;

                DebugLogger.Assert(stateType != null, "StateType is null");
                DebugLogger.Assert(renderer != null, "Renderer is null");
                DebugLogger.Assert(conditions != null && conditions.Length > 0, "Conditions is null");

                AbstractAgentState stateInstance = (AbstractAgentState)Activator.CreateInstance(stateType, agent, renderer, animationHash, conditions);
                stateInstance.Initialize();

                _states.Add((byte)stateSO.StateIndex, stateInstance);
            }
        }

        public void ChangeState(byte stateIndex, float transitionDuration = 0.1f)
        {
            _states.TryGetValue(stateIndex, out AbstractAgentState state);

            DebugLogger.Assert(state != null, "State is null");

            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter(transitionDuration);
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}