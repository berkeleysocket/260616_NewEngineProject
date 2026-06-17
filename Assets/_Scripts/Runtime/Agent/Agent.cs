using Runtime.Agents.ModuleSystem;
using Runtime.Agents.FSM;

using UnityEngine;

namespace Runtime.Agents
{
    public abstract class Agent : ModuleOwner 
    {
        [SerializeField] protected AgentStateListSO stateSOList;
        public StateMachine StateMachine { get; protected set; } = new StateMachine();

        private void Update()
        {
            StateMachine?.Update();
        }
    }
}