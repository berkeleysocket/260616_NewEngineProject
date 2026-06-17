using Core.Utilities;
using GameModules.AnimationParams;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    [CreateAssetMenu(fileName = "AgentStateSO", menuName = "SO/AgentStateSO")]
    public class AgentStateSO : DescriptionSO
    {
        [field: SerializeField] public string StateName { get; private set; }
        [field: SerializeField] public string ClassName { get; private set; }
        [field: SerializeField] public AnimationParameterSO AnimationParamSO { get; private set; }
        [field: SerializeField] public StateType StateIndex { get; private set; }
        [field: SerializeField] public StateConditionSO[] Conditions { get; private set; }

        public int StateNameHash { get; private set; }

        private void OnValidate()
        {
            if(StateName != null)
                this.StateNameHash = Animator.StringToHash(StateName);
        }
    }
}