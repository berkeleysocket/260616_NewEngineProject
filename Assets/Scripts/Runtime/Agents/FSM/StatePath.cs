using Scripts.Runtime.Agents.FSM.SO;

using System;

namespace Scripts.Runtime.Agents.FSM
{
    [Serializable]
    public struct StatePath
    {
        public StateType DestinationState;
        public StateConditionSO Condition;
    }
}