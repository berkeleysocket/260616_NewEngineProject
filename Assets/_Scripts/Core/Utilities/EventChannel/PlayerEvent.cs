using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Player
{
    public class PlayerEvent { };

    public class PlayerMoveKeyInputEvent : GameEvent
    {
        public Vector2 direction;
    }
    public class PlayerDashKeyInputEvent : GameEvent { }
    public class PlayerIsDashingEvent : GameEvent { }
    public class PlayerCompletedDashEvent : GameEvent { }
}

