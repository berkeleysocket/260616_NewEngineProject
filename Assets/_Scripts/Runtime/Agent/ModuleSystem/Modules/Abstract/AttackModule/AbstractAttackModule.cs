using Runtime.Agents.ModuleSystem.Interface;

namespace Runtime.Agents.ModuleSystem
{
    public abstract class AbstractAttackModule : AbstractModule, IAttacker
    {
        protected override void OnInitialize()
        {
        }

        public abstract void Attack();
    }
}

