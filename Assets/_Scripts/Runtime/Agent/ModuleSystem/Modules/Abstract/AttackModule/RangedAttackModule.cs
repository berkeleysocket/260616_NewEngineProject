using Core.ObjectPool;
using Core.Utilities.EventChannelSystem;

using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    public class RangedAttackModule : AbstractAttackModule
    {
        [SerializeField] private PoolItemSO projectileSO;
        [SerializeField] private EventChannelSO createChannel;
        [SerializeField] private Transform firePos;

        public override void OnAttack()
        {
            CreateEvents.ShootPoolingProjectile.Initialize(projectileSO, firePos.position, Quaternion.LookRotation(firePos.forward));
            createChannel.RaiseEvent(CreateEvents.ShootPoolingProjectile);
        }
    }
}