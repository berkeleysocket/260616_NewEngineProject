using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Player
{
    public class PlayerEvent { };

    public class PlayerMoveInputEvent : GameEvent
    {
        public Vector2 direction;
    }
}

