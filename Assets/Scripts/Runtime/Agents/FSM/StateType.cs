namespace Scripts.Runtime.Agents.FSM
{
    public enum StateType : byte
    {
        IDLE = 0,
        RUN,
        DASH,
        DASHATTACK,
        PATROL,
        ATTACK
    }
}
