using Core.Utilities;
using GameModules.AnimationParams;
using Runtime.FSM;

using UnityEngine;

namespace Runtime.Agents.FSM
{
    public abstract class StateSO : DescriptionSO
    {
        [field: SerializeField] public string StateName { get; private set; }
        [field: SerializeField] public string ClassName { get; private set; }
        [field: SerializeField] public AnimationParamSO AnimationParamSO { get; private set; }
        [field: SerializeField] public StateType StateType { get; private set; }

        public int StateNameHash { get; private set; }

        private void OnValidate()
        {
            if(StateName != null)
                this.StateNameHash = Animator.StringToHash(StateName);
        }
    }
}