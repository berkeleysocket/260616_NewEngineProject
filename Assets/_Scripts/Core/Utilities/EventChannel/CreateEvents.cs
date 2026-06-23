using Core.ObjectPool;

using UnityEngine;

namespace Core.Utilities.EventChannelSystem
{
    public class CreateEvents 
    {
        public static readonly ShowPoolingVfxEvent ShowPoolingVfxEvent = new ShowPoolingVfxEvent();
        public static readonly ShowPoolingProjectileEvent ShowPoolingProjectile = new ShowPoolingProjectileEvent();
    }

    public class ShowPoolingVfxEvent : ChannelEvent
    {
        public PoolItemSO ItemData { get; private set; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public void Initialize(PoolItemSO itemData, Vector3 position, Quaternion rotation)
        {
            this.ItemData = itemData;
            this.Position = position;
            this.Rotation = rotation;
        }
    }

    public class ShowPoolingProjectileEvent : ChannelEvent
    {
        public PoolItemSO ItemData { get; private set; }
        public Vector3 Position { get; private set; }
        public Quaternion Rotation { get; private set; }

        public void Initialize(PoolItemSO itemData, Vector3 position, Quaternion rotation)
        {
            this.ItemData = itemData;
            this.Position = position;
            this.Rotation = rotation;
        }
    }
}
