using UnityEngine;

namespace Core.Utilities.EventChannelSystem
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

    public class IsDashingEvent : ChannelEvent { }
    public class CompletedDashEvent : ChannelEvent { }

    public class IsDashAttackingEvent : ChannelEvent { }
    public class CompletedDashAttackEvent : ChannelEvent { }
}