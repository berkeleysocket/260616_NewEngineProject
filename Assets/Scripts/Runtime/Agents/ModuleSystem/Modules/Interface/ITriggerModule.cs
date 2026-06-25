using Runtime.Agents.ModuleSystem;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;
using System;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.Interface
{
    public interface ITriggerModule : IModule
    {
        event Action<SkillType> CastSkill;
        event Action Moved;

        void OnCastSkill(SkillType skillType);
        void OnMoved();
    }
}