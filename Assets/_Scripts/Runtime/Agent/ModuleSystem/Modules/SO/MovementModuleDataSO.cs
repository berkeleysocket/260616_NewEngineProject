using UnityEngine;

namespace Runtime.Agents.ModuleSystem.SO
{
    [CreateAssetMenu(fileName = "MovementModuleDataSO", menuName = "SO/ModuleSystem/MovementModuleDataSO")]
    public class MovementModuleDataSO : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float DashSpeed { get; private set; }
        [field: SerializeField] public float DashDuration { get; private set; }
        [field: SerializeField] public float DashCooldown { get; private set; }
        [field: SerializeField] public float DashAttackSpeed { get; private set; }
        [field: SerializeField] public float DashAttackDuration { get; private set; }
        [field: SerializeField] public float DashAttackCooldown { get; private set; }
    }
}

