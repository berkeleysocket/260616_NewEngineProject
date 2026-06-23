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

        public override void Attack()
        {
            CreateEvents.ShowPoolingProjectile.Initialize(projectileSO, firePos.position, firePos.rotation);
            createChannel.RaiseEvent(CreateEvents.ShowPoolingProjectile);
        }
    }
}