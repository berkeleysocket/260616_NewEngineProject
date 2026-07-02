using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public abstract class AbstractSkill : MonoBehaviour
    {
        [SerializeField] protected SkillDataSO SkillData;
        
        public SkillType Type { get; protected set; }

        protected ModuleOwner owner;
        protected bool IsCooldownReady => _cooldown == 0 || _lastUsingTime == 0 ? true : Time.time - _lastUsingTime >= _cooldown;

        private float _lastUsingTime;
        private float _cooldown;

        public void Initialize(ModuleOwner owner)
        {
            this.owner = owner;
            this.Type = SkillData.SkillType;
            this._cooldown = SkillData.Cooldown;
            OnInitialize();
        }
        protected abstract void OnInitialize();

        public void Cast()
        {
            this._lastUsingTime = Time.time;
            OnCast();
        }
        public abstract void OnCast();

        public abstract bool CanCast(); 

        public virtual void StopSkill()
        {
            _lastUsingTime = Time.time;
        }
    }
}