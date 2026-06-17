using UnityEngine;

namespace Runtime.Agents.FSM
{
    public abstract class StateConditionSO : ScriptableObject
    {
        [field: SerializeField] public StateType NextStateType;
        public abstract void Initialize(Agent agent); 
        public abstract bool CheckCondition();
    }
}