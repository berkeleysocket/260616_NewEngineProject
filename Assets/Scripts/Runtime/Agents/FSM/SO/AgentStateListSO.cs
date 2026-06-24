using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO
{
    [CreateAssetMenu(fileName = "AgentStateListSO", menuName = "SO/AgentStateListSO", order = 0)]
    public class AgentStateListSO : ScriptableObject
    {
        [field: SerializeField] public AgentStateSO[] Values { get; private set; }

        private void OnValidate()
        {
            if(Values != null && Values.Length > 0)
            {
                Values = Values.OrderBy((stateSO) => stateSO.StateIndex).ToArray();
            }
        }
    }
}