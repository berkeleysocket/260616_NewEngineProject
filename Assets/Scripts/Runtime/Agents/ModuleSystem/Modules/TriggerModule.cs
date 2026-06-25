using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;
using System;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules
{
    public class TriggerModule : AbstractModule, ITriggerModule
    {
        public event Action<SkillType> CastSkill;
        public event Action Moved;

        protected override void OnInitialize()
        {
        }

        public void OnCastSkill(SkillType skillType) => CastSkill?.Invoke(skillType);
        public void OnMoved() => Moved?.Invoke();
    }
}