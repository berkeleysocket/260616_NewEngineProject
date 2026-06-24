using Scripts.Core.ObjectPool.SO;

using UnityEngine;

namespace Scripts.Core.EventChannels
{
    public class CreateEvents 
    {
        public static readonly ShowPoolingVfxEvent ShowPoolingVfxEvent = new ShowPoolingVfxEvent();
        public static readonly ShootPoolingProjectileEvent ShootPoolingProjectile = new ShootPoolingProjectileEvent();
    }

    public class ShowPoolingVfxEvent : GameEvent
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

    public class ShootPoolingProjectileEvent : GameEvent
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
