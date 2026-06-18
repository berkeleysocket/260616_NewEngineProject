using System.Collections.Generic;
using UnityEngine;

namespace Core.ObjectPool
{
    public class Pool
    {
        private readonly Stack<IPoolable> _pool;
        private readonly GameObject _prefab;
        private readonly Transform _parentTrm;

        public Pool(IPoolable poolable, Transform parent, int initCount)
        {
            _pool = new Stack<IPoolable>(initCount);
            _prefab = poolable.GameObject;
            _parentTrm = parent;

            for (int i = 0; i < initCount; i++)
            {
                GameObject go = Object.Instantiate(_prefab, _parentTrm);
                go.SetActive(false);
                IPoolable item = go.GetComponent<IPoolable>();

                _pool.Push(item);
            }
        }

        public IPoolable Pop()
        {
            IPoolable item;

            if(_pool.Count > 0)
            {
                item = _pool.Pop();
                item.GameObject.SetActive(true);
            }
            else
            {
                GameObject go = Object.Instantiate(_prefab, _parentTrm);
                item = go.GetComponent<IPoolable>();
            }
            item.ResetItem();

            return item;
        }

        public void Push(IPoolable item)
        {
            item.GameObject.SetActive(false);
            _pool.Push(item);
        }
    }
}