using UnityEngine;

namespace Scripts.Core.EventChannels
{
    public class PlayerEvents 
    { 
    
    }

    public class MoveKeyInputEvent : ChannelEvent
    {
        public Vector2 direction;
    }

    public class DashKeyInputEvent : ChannelEvent { }
    public class DashAttackKeyInputEvent : ChannelEvent { }
}