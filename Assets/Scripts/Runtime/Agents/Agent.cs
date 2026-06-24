using Scripts.Runtime.Agents.FSM;
using Scripts.Runtime.Agents.FSM.SO;
using Scripts.Runtime.Agents.ModuleSystem;

using UnityEngine;

namespace Scripts.Runtime.Agents
{
    public abstract class Agent : ModuleOwner 
    {
        [SerializeField] protected StateType startState; 
        [SerializeField] protected AgentStateListSO stateSOList;

        public StateMachine StateMachine { get; protected set; } = new StateMachine();

        protected override void OnInitialize()
        {
            this.StateMachine.Initialize(this, stateSOList.Values);
            this.StateMachine.ChangeState((byte)startState);
        }

        private void Update()
        {
            StateMachine?.Update();
        }
    }
}