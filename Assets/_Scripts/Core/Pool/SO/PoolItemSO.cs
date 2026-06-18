using UnityEngine;

namespace Core.Pool
{
    [CreateAssetMenu(fileName = "PoolItemSO", menuName = "SO/PoolItem")]
    public class PoolItemSO : ScriptableObject
    {
        [field: SerializeField] public GameObject ItemObject { get; private set; }
        [field: SerializeField] public int InitCount { get; private set; }
    }
}