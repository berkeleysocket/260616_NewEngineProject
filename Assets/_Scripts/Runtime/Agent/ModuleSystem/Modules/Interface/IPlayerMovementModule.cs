namespace Runtime.Agents.ModuleSystem.Interface
{
    public interface IPlayerMovementModule : IMovable
    {
        public bool IsDashAttacking { get; }
    }
}