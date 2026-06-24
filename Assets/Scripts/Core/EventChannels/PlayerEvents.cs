using UnityEngine;

namespace Scripts.Core.EventChannels
{
    public class PlayerEvents 
    {
        public static MoveKeyInputEvent MoveKeyInputEvent { get; private set; } = new MoveKeyInputEvent();
        public static DashKeyInputEvent DashKeyInputEvent { get; private set; } = new DashKeyInputEvent();
        public static DashAttackKeyInputEvent DashAttackKeyInputEvent { get; private set; } = new DashAttackKeyInputEvent();
        public static ActiveSkillKeyInputEvent ActiveSkillKeyInputEvent { get; private set; } = new ActiveSkillKeyInputEvent();
    }

    public class MoveKeyInputEvent : GameEvent
    {
        public Vector2 direction;
    }

    public class DashKeyInputEvent : GameEvent { }
    public class DashAttackKeyInputEvent : GameEvent { }
    public class ActiveSkillKeyInputEvent : GameEvent { }
}