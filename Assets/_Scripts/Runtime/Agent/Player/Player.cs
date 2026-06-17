using Runtime.Agents.FSM;

namespace Runtime.Agents
{
    public class Player : Agent
    {
        protected override void OnInitialize()
        {
            this.StateMachine.Initialize(this, stateSOList.Values);
            this.StateMachine.ChangeState((byte)StateType.IDLE);
        }
    }
}