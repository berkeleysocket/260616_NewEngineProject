using Core.Effects;
using Core.Utilities.EventChannelSystem;
using Runtime.Agents.ModuleSystem;

using UnityEngine;

namespace Core.ObjectPool
{
    public class CreateManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private EventChannelSO createChannel;
        [SerializeField] private PoolManagerSO poolManagerAsset;

        private void OnDestroy()
        {
            createChannel.RemoveListener<ShowPoolingVfxEvent>(HandleShowPoolingVfx);
            createChannel.RemoveListener<ShowPoolingProjectileEvent>(HandleShowPoolingProjectile);
        }

        public void Initialize()
        {
            poolManagerAsset.InitializePool(transform);
            createChannel.AddListener<ShowPoolingVfxEvent>(HandleShowPoolingVfx);
        }

        private void HandleShowPoolingVfx(ShowPoolingVfxEvent evt)
        {
            PoolableVfx vfx = poolManagerAsset.Pop<PoolableVfx>(evt.ItemData);
            vfx.Deactivated += HandleOnDeactivated;
            vfx.PlayVfx(evt.Position, evt.Rotation);
        }

        private void HandleShowPoolingProjectile(ShowPoolingProjectileEvent evt)
        {
            PoolableProjectile projectile = poolManagerAsset.Pop<PoolableProjectile>(evt.ItemData);
            projectile.Deactivated += HandleOnDeactivated;
            projectile.Shoot(evt.Position, evt.Rotation);
        }

        private void HandleOnDeactivated<T>(AbstractMonoPoolable<T> poolableObj) where T : AbstractMonoPoolable<T>
        {
            poolableObj.Deactivated -= HandleOnDeactivated;
            poolManagerAsset.Push(poolableObj);
        }
    }
}