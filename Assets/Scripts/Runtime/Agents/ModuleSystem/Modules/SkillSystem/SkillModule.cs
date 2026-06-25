using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Core.Utilities;
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

            pressKeyChannel.AddListener<ActiveSkillKeyInputEvent>(HandleActiveSkill01KeyInputEvent);
            pressKeyChannel.AddListener<ActiveSkillKeyInputEvent>(HandleActiveSkill02KeyInputEvent);
            pressKeyChannel.AddListener<ActiveSkillKeyInputEvent>(HandleActiveSkill03KeyInputEvent);
        }

        public void SkillCast(SkillType skillType)
        {
            if (skills.TryGetValue(skillType, out var skill))
                skill.Cast();
        }

        private void HandleActiveSkill01KeyInputEvent(ActiveSkillKeyInputEvent args)
        {
            SkillCast(SkillType.ActiveSkill01);
        }

        private void HandleActiveSkill02KeyInputEvent(ActiveSkillKeyInputEvent args)
        {
            SkillCast(SkillType.ActiveSkill02);
        }

        private void HandleActiveSkill03KeyInputEvent(ActiveSkillKeyInputEvent args)
        {
            SkillCast(SkillType.ActiveSkill03);
        }
    }
}