using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public abstract class AbstractSkill : MonoBehaviour
    {
        [SerializeField] private SkillDataSO SkillData;
        
        protected ModuleOwner owner; 
        public SkillType SkillType { get; protected set; }

        public void Initialize(ModuleOwner owner)
        {
            this.owner = owner;
            this.SkillType = SkillData.SkillType;
            OnInitialize();
        }
        
        protected abstract void OnInitialize();
        public abstract void Cast();
    }
}