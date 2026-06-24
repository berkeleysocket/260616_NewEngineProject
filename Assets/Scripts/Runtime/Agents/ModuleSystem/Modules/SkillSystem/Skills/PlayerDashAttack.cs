using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Core.ObjectPool.SO;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using System.Collections;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public class PlayerDashAttack : AbstractSkill
    {
        [SerializeField] private EventChannelSO CreateChannel;
        [SerializeField] private PoolItemSO VfxDashAttackSO;

        private PlayerDashAttackDataSO _playerDashAttackData;
        private MovementModule _movementModule;
        private Coroutine _dashAttackCoroutine;
        private WaitForSeconds _dashAttackTimer;
        private float _speed;
        private float _duration;

        protected override void OnInitialize()
        {
            this._movementModule = owner.GetModule<MovementModule>();
            this._playerDashAttackData = SkillData as PlayerDashAttackDataSO;

            if (_playerDashAttackData != null)
            {
                this._speed = _playerDashAttackData.Speed;
                this._duration = _playerDashAttackData.Duration;
            }

            this._dashAttackTimer = new WaitForSeconds(_duration);
        }

        public override void Cast()
        {
            _movementModule.CanMove = false;
            _dashAttackCoroutine = StartCoroutine(DashAttackCoroutine());
        }

        public override bool CanCast()
        {
            return IsCooldownReady;
        }

        public override void StopSkill()
        {
            base.StopSkill();
            if(_dashAttackCoroutine != null)
            {
                StopCoroutine(_dashAttackCoroutine);
                _dashAttackCoroutine = null;
                _movementModule.CanMove = true;
            }
        }

        private IEnumerator DashAttackCoroutine()
        {
            Vector3 dashDirection = new Vector3(_movementModule.LastMoveDirection.x, 0, _movementModule.LastMoveDirection.y);
            _movementModule.RotateTo(dashDirection);
            CreateEvents.ShowPoolingVfxEvent.Initialize(VfxDashAttackSO, owner.transform.position, owner.transform.rotation);
            CreateChannel.RaiseEvent(CreateEvents.ShowPoolingVfxEvent);
            _movementModule.SpeedUp(_speed);
            _movementModule.Move(dashDirection);

            yield return _dashAttackTimer;

            _dashAttackCoroutine = null;
        }
    }
}

