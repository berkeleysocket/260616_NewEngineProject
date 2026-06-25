using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SO
{
    [CreateAssetMenu(fileName = "MovementModuleDataSO", menuName = "SO/ModuleSystem/MovementModuleData")]
    public class MovementModuleDataSO : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
    }
}

