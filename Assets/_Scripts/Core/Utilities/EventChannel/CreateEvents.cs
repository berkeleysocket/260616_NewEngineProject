using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Core.ObjectPool
{
    public class CreateEvents 
    {
        public static readonly ShowPoolingVfxEvent ShowPoolingVfxEvent = new ShowPoolingVfxEvent();
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
}
