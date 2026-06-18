using UnityEngine;

namespace Core.Pool
{
    public interface IPoolable
    {
        PoolItemSO Item { get; set; }
        GameObject GameObject { get; set; }
        void ResetItem();
    }
}