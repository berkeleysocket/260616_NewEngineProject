using Scripts.Runtime.Agents.ModuleSystem;

namespace Runtime.Agents.ModuleSystem
{
    public interface IModule 
    {
        public void Initialize(ModuleOwner owner);
    }
}