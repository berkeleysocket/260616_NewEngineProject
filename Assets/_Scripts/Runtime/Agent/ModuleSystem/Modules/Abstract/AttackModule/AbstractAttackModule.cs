using Runtime.Agents.ModuleSystem.Interface;
using System;

namespace Runtime.Agents.ModuleSystem
{
    public abstract class AbstractAttackModule : AbstractModule, IAttacker
    {
        public event Action isAttacking;
        protected override void OnInitialize()
        {
        }

        public void Attack()
        {
            isAttacking?.Invoke();
            OnAttack();
        }
        public abstract void OnAttack();
    }
}

