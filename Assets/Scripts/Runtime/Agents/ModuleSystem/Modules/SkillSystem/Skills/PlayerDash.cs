using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Core.ObjectPool.SO;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using System.Collections;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules.SkillSystem
{
    public class PlayerDash : AbstractSkill
    {
        [SerializeField] private EventChannelSO CreateChannel;
        [SerializeField] private PoolItemSO VfxDashSO;

        private PlayerDashDataSO _playerDashData;
        private MovementModule _movementModule;
        private Coroutine _dashCoroutine;
        private WaitForSeconds _dashTimer;
        private float _speed;
        private float _duration;

        protected override void OnInitialize()
        {
            this._movementModule = owner.GetModule<MovementModule>();
            this._playerDashData = SkillData as PlayerDashDataSO;

            if (_playerDashData != null)
            {
                this._speed = _playerDashData.Speed;
                this._duration = _playerDashData.Duration;
            }

            this._dashTimer = new WaitForSeconds(_duration);
        }

        public override void Cast()
        {
            _dashCoroutine = StartCoroutine(DashAttackCoroutine());
        }

        public override bool CanCast()
        {
            return IsCooldownReady;
        }

        public override void StopSkill()
        {
            base.StopSkill();
            if (_dashCoroutine != null)
            {
                StopCoroutine(_dashCoroutine);
                _dashCoroutine = null;
            }
        }

        private IEnumerator DashAttackCoroutine()
        {
            Vector3 dashDirection = new Vector3(_movementModule.LastMoveDirection.x, 0, _movementModule.LastMoveDirection.y);
            _movementModule.RotateTo(dashDirection);
            CreateEvents.ShowPoolingVfxEvent.Initialize(VfxDashSO, owner.transform.position, owner.transform.rotation);
            CreateChannel.RaiseEvent(CreateEvents.ShowPoolingVfxEvent);
            _movementModule.SpeedUp(_speed);
            _movementModule.Move(dashDirection);

            yield return _dashTimer;

            _dashCoroutine = null;
        }
    }
}