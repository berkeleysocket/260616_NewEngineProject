using Runtime.Agents.ModuleSystem;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.Interface
{
    public interface ISkillModule : IModule
    {
        bool IsSkillCasting { get; }

        void SkillCast(SkillType skillType);
    }
}