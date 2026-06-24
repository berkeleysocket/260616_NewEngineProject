using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SO
{
    [CreateAssetMenu(fileName = "PlayerDashAttackDataSO", menuName = "SO/SkillData/DashAttackData", order = 0)]
    public class PlayerDashAttackDataSO : SkillDataSO
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
    }
}