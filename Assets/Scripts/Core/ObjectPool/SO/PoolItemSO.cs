using UnityEngine;

namespace Scripts.Core.ObjectPool.SO
{
    [CreateAssetMenu(fileName = "PoolItemSO", menuName = "SO/ObjectPool/PoolItem")]
    public class PoolItemSO : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public int InitCount { get; private set; }
    }
}