using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public class SkillModule : AbstractModule, ISkillModule
    {
        [SerializeField] private EventChannelSO pressKeyChannel;

        public bool IsSkillCasting { get => currentSkill != null; }

        private Dictionary<SkillType, AbstractSkill> skills;
        private AbstractSkill currentSkill;

        protected override void OnInitialize()
        {
            skills = new Dictionary<SkillType, AbstractSkill>();

            foreach(var skill in GetComponentsInChildren<AbstractSkill>())
            {
                skill.Initialize(owner);
                skills[skill.Type] = skill;
            }

            foreach (var skill in skills.Values)
                skill.Initialize(owner);

            pressKeyChannel.AddListener<ActiveSkillKeyInputEvent>(HandleActiveSkillKeyInputEvent);
        }

        public void SkillCast(SkillType skillType)
        {
            if (skills.TryGetValue(skillType, out var skill))
                if(skill.CanCast())
                    skill.Cast();
        }

        private void HandleActiveSkillKeyInputEvent(ActiveSkillKeyInputEvent args)=> SkillCast(args.ActiveSkillType);
    }
}