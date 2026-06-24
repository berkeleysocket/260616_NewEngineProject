using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public abstract class AbstractSkill : MonoBehaviour
    {
        [SerializeField] protected SkillDataSO SkillData;
        
        public SkillType SkillType { get; protected set; }

        protected ModuleOwner owner;
        protected bool IsCooldownReady => SkillData.Cooldown == 0 ? true : Time.time - _lastUsingTime >= SkillData.Cooldown;

        private float _lastUsingTime;
        private float _cooldown;

        public void Initialize(ModuleOwner owner)
        {
            this.owner = owner;
            this.SkillType = SkillData.SkillType;
            this._cooldown = SkillData.Cooldown;
            OnInitialize();
        }
        protected abstract void OnInitialize();

        public abstract void Cast();
        public abstract bool CanCast(); 

        public virtual void StopSkill()
        {
            _lastUsingTime = Time.time;
        }
    }
}