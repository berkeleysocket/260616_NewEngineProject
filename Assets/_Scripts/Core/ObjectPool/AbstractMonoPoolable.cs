using Core.ObjectPool;
using UnityEngine;

namespace Core.ObjectPool
{
    public abstract class AbstractMonoPoolable : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public PoolItemSO Item { get; set; }
        public GameObject GameObject => this != null ? this.gameObject : null;

        public abstract void ResetItem();
    }
}
