using Core.Effects;
using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Core.ObjectPool
{
    public class CreateManager : MonoBehaviour, IInitializable
    {
        [SerializeField] private GameEventChannelSO createChannel;
        [SerializeField] private PoolManagerSO poolManagerAsset;

        private void OnDestroy()
        {
            createChannel.RemoveListener<ShowPoolingVfxEvent>(HandleShowPoolingVfx);
        }

        public void Initialize()
        {
            poolManagerAsset.InitializePool(transform);
            createChannel.AddListener<ShowPoolingVfxEvent>(HandleShowPoolingVfx);
        }

        private void HandleShowPoolingVfx(ShowPoolingVfxEvent evt)
        {
            PoolableVfx vfx = poolManagerAsset.Pop<PoolableVfx>(evt.ItemData);
            vfx.OnVfxEnd += HandleVfxEnd;
            vfx.PlayVfx(evt.Position, evt.Rotation);
        }

        private void HandleVfxEnd(PoolableVfx targetVfx)
        {
            targetVfx.OnVfxEnd -= HandleVfxEnd;
            poolManagerAsset.Push(targetVfx);
        }
    }
}