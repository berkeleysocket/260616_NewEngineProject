using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

using System.Collections.Generic;
using System.Linq;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public class SkillModule : AbstractModule, ISkillCaster
    {
        public bool IsSkillCasting { get => currentSkill != null; }
        
        private Dictionary<SkillType,AbstractSkill> skills;
        private AbstractSkill currentSkill;
        
        protected override void OnInitialize()
        {
            skills = new Dictionary<SkillType, AbstractSkill>();
            skills = GetComponentsInChildren<AbstractSkill>(true)
                .ToDictionary((skill) => skill.SkillType, (skill) => skill);

            foreach (var skill in skills.Values)
                skill.Initialize(owner);
        }

        public void SkillCast(SkillType skillType)
        {
            if (skills.TryGetValue(skillType, out var skill))
                skill.Cast();
        }
    }
}