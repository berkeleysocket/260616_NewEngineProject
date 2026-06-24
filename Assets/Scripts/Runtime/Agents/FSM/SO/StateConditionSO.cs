using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO
{
    public abstract class StateConditionSO : ScriptableObject
    {
        public abstract void Initialize(Agent agent); 
        public abstract bool CheckCondition();
    }
}