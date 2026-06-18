using System.Collections.Generic;
using UnityEngine;

namespace Core.ObjectPool
{
    [CreateAssetMenu(fileName = "PoolManager", menuName = "SO/ObjectPool/PoolManager")]
    public class PoolManagerSO : ScriptableObject
    {
        public List<PoolItemSO> itemList = new();

        private Dictionary<PoolItemSO, Pool> _pools = new();
        private Transform _rootTrm;

        public void InitializePool(Transform rootTrm)
        {
            this._rootTrm = rootTrm;
            this._pools = new Dictionary<PoolItemSO, Pool>();

            foreach (var item in itemList)
            {
                IPoolable poolable = item.Prefab.GetComponent<IPoolable>();
                
                Pool pool = new Pool(poolable, _rootTrm, item.InitCount);
                _pools.Add(item, pool);
            }
        }

        public T Pop<T>(PoolItemSO item) where T : IPoolable
        {
            if (_pools.TryGetValue(item, out Pool pool))
                return (T)pool.Pop();

            return default;
        }

        public void Push(IPoolable item)
        {
            if (_pools.TryGetValue(item.Item, out Pool pool))
                pool.Push(item);
        }
    }
}
