using UnityEngine;

namespace Core.ObjectPool
{
    public interface IPoolable
    {
        PoolItemSO Item { get; set; }
        GameObject GameObject { get; }
        void ResetItem();
    }
}