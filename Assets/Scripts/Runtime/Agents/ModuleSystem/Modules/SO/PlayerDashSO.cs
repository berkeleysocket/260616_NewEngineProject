using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SO
{
    [CreateAssetMenu(fileName = "PlayerDashDataSO", menuName = "SO/SkillData/PlayerDashData", order = 0)]
    public class PlayerDashDataSO : SkillDataSO
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
    }
}