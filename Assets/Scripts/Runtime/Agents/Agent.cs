using Scripts.Runtime.Agents.FSM;
using Scripts.Runtime.Agents.FSM.SO;
using Scripts.Runtime.Agents.ModuleSystem;

using UnityEngine;

namespace Scripts.Runtime.Agents
{
    public abstract class Agent : ModuleOwner 
    {
        [SerializeField] private AgentStateMachineDataSO startMachineData;

        public StateMachine StateMachine { get; protected set; } = new StateMachine();

        protected override void OnInitialize()
        {
            this.StateMachine.Initialize(this, startMachineData.Values);
            this.StateMachine.ChangeState(startMachineData.StartState);
        }

        private void Update()
        {
            StateMachine?.Update();
        }
    }
}