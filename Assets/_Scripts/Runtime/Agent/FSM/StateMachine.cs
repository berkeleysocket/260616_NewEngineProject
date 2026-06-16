using Core.Utilities;
using Runtime.Agents;
using Runtime.Agents.FSM;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;

using System;
using System.Collections.Generic;

namespace Runtime.FSM
{
    public class StateMachine
    {
        private Dictionary<Type, AbstractState> _states;
        private AbstractState currentState;

        public void Initialize(Agent agent, StateSO[] stateList)
        {
            this._states = new Dictionary<Type, AbstractState>();

            foreach(StateSO stateSO in stateList)
            {
                Type stateType = Type.GetType(stateSO.ClassName);
                IRenderer renderer = agent.GetModule<RendererModule>();
                int animationHash = stateSO.AnimationParamSO.ClipHash;

                DebugLogger.ValidateObject(stateType);
                DebugLogger.ValidateObject(renderer);
                DebugLogger.ValidateObject(stateType);

                AbstractState stateInstance = (AbstractState)Activator.CreateInstance(stateType, renderer, animationHash);

                _states.Add(stateType, stateInstance);
            }
        }

        public void ChangeState(StateType stateType)
        {
            byte idx = (byte)stateType;

            _states
        }
    }
}