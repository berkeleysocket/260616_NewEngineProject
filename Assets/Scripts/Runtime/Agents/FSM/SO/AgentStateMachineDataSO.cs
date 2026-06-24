using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO
{
    [CreateAssetMenu(fileName = "AgentStateMachineDataSO", menuName = "SO/AgentStateMachineData", order = 0)]
    public class AgentStateMachineDataSO : ScriptableObject
    {
        [field: SerializeField] public StateType StartState { get; private set; }
        [field: SerializeField] public AgentStateSO[] Values { get; private set; }

        private void OnValidate()
        {
            if(Values != null && Values.Length > 0)
            {
                Values = Values.OrderBy((stateSO) => stateSO.StateType).ToArray();
            }
        }
    }
}