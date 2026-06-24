using Scripts.Core.Utilities.SO;

using UnityEngine;

namespace Scripts.Runtime.Agents.FSM.SO
{
    [CreateAssetMenu(fileName = "AgentStateSO", menuName = "SO/AgentStateSO")]
    public class AgentStateSO : ScriptableObject
    {
        [field: SerializeField] public string StateName { get; private set; }
        [field: SerializeField] public string ClassName { get; private set; }
        [field: SerializeField] public AssetNameSO AnimationParamSO { get; private set; }
        [field: SerializeField] public StateType StateType { get; private set; }
        [field: SerializeField] public StatePath[] Paths { get; private set; }

        public int StateNameHash { get; private set; }

        private void OnValidate()
        {
            if(StateName != null)
                this.StateNameHash = Animator.StringToHash(StateName);
        }
    }
}