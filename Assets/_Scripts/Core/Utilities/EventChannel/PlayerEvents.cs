using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Player
{
    public class PlayerEvents 
    { 
    
    }

    public class MoveKeyInputEvent : GameEvent
    {
        public Vector2 direction;
    }
    public class DashKeyInputEvent : GameEvent { }
    public class DashAttackKeyInputEvent : GameEvent { }

    public class IsDashingEvent : GameEvent { }
    public class CompletedDashEvent : GameEvent { }

    public class IsDashAttackingEvent : GameEvent { }
    public class CompletedDashAttackEvent : GameEvent { }
}