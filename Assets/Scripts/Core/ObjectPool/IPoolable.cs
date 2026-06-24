using Scripts.Core.ObjectPool.SO;

using UnityEngine;

namespace Scripts.Core.ObjectPool
{
    public interface IPoolable
    {
        PoolItemSO Item { get; set; }
        GameObject GameObject { get; }
        void ResetItem();
    }
}