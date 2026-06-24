using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SO
{
    public abstract class SkillDataSO : ScriptableObject
    {
        [field: SerializeField] public SkillType SkillType { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
    }
}