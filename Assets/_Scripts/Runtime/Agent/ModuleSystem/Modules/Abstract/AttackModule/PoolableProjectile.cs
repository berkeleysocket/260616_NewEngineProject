using Core.ObjectPool;

using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    public class PoolableProjectile : AbstractMonoPoolable<PoolableProjectile>
    {
        private bool isActive = false;
        private float _speed = 2f;

        private void Update()
        {
            if (!isActive) return;
            Move();
        }

        public override void ResetItem()
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            isActive = false;
        }

        public void Shoot(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
            isActive = true;
        }

        private void Move()
        {
            transform.forward *= _speed * Time.deltaTime;
        }
    }
}