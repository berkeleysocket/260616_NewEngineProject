using Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem;
using UnityEngine;

namespace Scripts.Core.EventChannels
{
    public class PlayerEvents 
    {
        public static MoveKeyInputEvent MoveKeyInputEvent { get; private set; } = new MoveKeyInputEvent();
        public static ActiveSkillKeyInputEvent ActiveSkillKeyInputEvent { get; private set; } = new ActiveSkillKeyInputEvent();
    }

    public class MoveKeyInputEvent : GameEvent
    {
        public Vector2 Direction;
    }

    public class ActiveSkillKeyInputEvent : GameEvent 
    {
        public SkillType ActiveSkillType;
    }
}