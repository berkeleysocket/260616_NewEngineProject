using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SO
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "SO/SkillData", order = 0)]
    public class SkillDataSO : ScriptableObject
    {
        [field: SerializeField] public SkillType SkillType { get; private set; }
    }
}