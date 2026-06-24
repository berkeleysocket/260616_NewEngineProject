namespace Scripts.Runtime.Agents.ModuleSystem.Modules.Interface
{
    public interface IMovable
    {
        public bool CanMove { get; set; }
        public bool IsMoving { get; }
    }
}