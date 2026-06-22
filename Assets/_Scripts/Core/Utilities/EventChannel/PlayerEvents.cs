using UnityEngine;

namespace Core.Utilities.EventChannelSystem
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