using UnityEngine;

namespace Core.ObjectPool
{
    [CreateAssetMenu(fileName = "PoolItemSO", menuName = "SO/ObjectPool/PoolItem")]
    public class PoolItemSO : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public int InitCount { get; private set; }
    }
}