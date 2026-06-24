using Core.Utilities;

namespace Runtime.Agents
{
    public class Enemy : Agent
    {
        protected override void OnInitialize()
        {
            DebugLogger.Log("OnInitialize");
        }
    }
}

