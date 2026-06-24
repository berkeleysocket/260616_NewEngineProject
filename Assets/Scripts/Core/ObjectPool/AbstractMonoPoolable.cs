using Scripts.Core.ObjectPool.SO;

using System;
using UnityEngine;

namespace Scripts.Core.ObjectPool
{
    public abstract class AbstractMonoPoolable<T> : MonoBehaviour, IPoolable where T : AbstractMonoPoolable<T>
    {
        [field: SerializeField] public PoolItemSO Item { get; set; }
        public GameObject GameObject => this != null ? this.gameObject : null;
        public Action<T> Deactivated;
        public abstract void ResetItem();
        protected void OnDeactivated()
        {
            Deactivated?.Invoke(this as T);
        }
    }
}