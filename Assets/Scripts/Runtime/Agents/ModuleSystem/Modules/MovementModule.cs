using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Core.ObjectPool.SO;
using Scripts.Core.Utilities;
using Scripts.Core.Utilities.SO;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using System.Collections;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules
{
    public class MovementModule : AbstractModule, IMovable
    {
        [SerializeField] CharacterController controller;
        [SerializeField] private MovementModuleDataSO movementData;
        [SerializeField] private EventChannelSO pressKeyChannel;
        [SerializeField] private EventChannelSO createChannel;
        [SerializeField] private AssetNameSO vfxFootstepAssetNameSO;
        [SerializeField] private PoolItemSO vfxDashSO;
        [SerializeField] private PoolItemSO vfxDashAttackSO;

        private VfxModule _vfxModule;
        private Coroutine _dashCoroutine;
        private Coroutine _dashCooldownCoroutine;
        private Coroutine _dashAttackCoroutine;
        private Coroutine _dashAttackCooldownCoroutine;

        private Vector3 _velocity = Vector3.zero;
        private Vector2 _lastMoveDirection = Vector2.zero;

        private bool _canDash = true;
        private bool _canDashAttack = true;

        private float _moveSpeed = 0f;
        private float _dashSpeed = 0f;
        private float _dashDuration = 0f;
        private float _dashCooldown = 0f;
        private float _dashAttackSpeed = 0f;
        private float _dashAttackDuration = 0f;
        private float _dashAttackCooldown = 0f;

        public bool IsMoving { get; private set; }
        public bool IsDashing { get; private set; }
        public bool IsDashAttacking { get; private set; }

        private void FixedUpdate()
        {
            if (initialized)
                controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            if (movementData != null)
            {
                this._moveSpeed = movementData.MoveSpeed;
                this._dashSpeed = movementData.DashSpeed;
                this._dashDuration = movementData.DashDuration;
                this._dashCooldown = movementData.DashCooldown;
                this._dashAttackSpeed = movementData.DashAttackSpeed;
                this._dashAttackDuration = movementData.DashAttackDuration;
                this._dashAttackCooldown = movementData.DashAttackCooldown;
            }

            DebugLogger.Assert(controller != null, "Controller is null");
            DebugLogger.Assert(pressKeyChannel != null, "PlayerMoveKeyInputChannel is null");
            DebugLogger.Assert(pressKeyChannel != null, "PlayerDashKeyInputChannel is null");
            DebugLogger.Assert(_vfxModule != null, "VfxModule is null");
            DebugLogger.Assert(vfxFootstepAssetNameSO != null, "VfxFootstepAssetNameSO is null");

            pressKeyChannel.AddListener<MoveKeyInputEvent>(OnMoveKeyInput);
            pressKeyChannel.AddListener<DashKeyInputEvent>(OnDashKeyInput);
            pressKeyChannel.AddListener<DashAttackKeyInputEvent>(OnDashAttackKeyInput);
        }

        private void Start()
        {
            _vfxModule?.StopVfx(vfxFootstepAssetNameSO.AssetNameHash);
        }

        private void Move(Vector2 direction)
        {
            _lastMoveDirection = direction;

            if (IsDashing || IsDashAttacking) return;

            _velocity = new Vector3(direction.x, 0, direction.y) * _moveSpeed;
            _vfxModule?.PlayVfx(vfxFootstepAssetNameSO.AssetNameHash);
            RotateTo(_velocity);

            IsMoving = direction.x != 0f || direction.y != 0f;
        }

        public void RotateTo(Vector3 direction)
        {
            if (direction.sqrMagnitude < Mathf.Epsilon) return;
            direction.y = 0;
            owner.transform.forward = direction.normalized;
        }

        public void Dash()
        {
            if (!initialized || !_canDash) return;

            if (_dashAttackCoroutine != null)
            {
                StopCoroutine(_dashAttackCoroutine);
                _dashAttackCoroutine = null;
                IsDashAttacking = false;

                if (_dashAttackCooldownCoroutine != null) StopCoroutine(_dashAttackCooldownCoroutine);
                _dashAttackCooldownCoroutine = StartCoroutine(DashAttackCooldownCoroutine());
            }

            if (_dashCoroutine != null) return;

            _dashCoroutine = StartCoroutine(DashCoroutine());
            //GameManager.Instance.SoundManager.PlayEffect(SfxType.Player_Dash);
        }

        private IEnumerator DashCoroutine()
        {
            IsDashing = true;
            _canDash = false;
            IsMoving = false;

            Vector3 dashDirection = GetDashDirection();
            RotateTo(dashDirection);
            CreateEvents.ShowPoolingVfxEvent.Initialize(vfxDashSO, owner.transform.position, owner.transform.rotation);
            createChannel.RaiseEvent(CreateEvents.ShowPoolingVfxEvent);
            _velocity = dashDirection * _dashSpeed;

            yield return new WaitForSeconds(_dashDuration);

            IsDashing = false;
            _dashCoroutine = null;

            Move(_lastMoveDirection);

            if (_dashCooldownCoroutine != null) StopCoroutine(_dashCooldownCoroutine);
            _dashCooldownCoroutine = StartCoroutine(DashCooldownCoroutine());
        }

        private IEnumerator DashCooldownCoroutine()
        {
            yield return new WaitForSeconds(_dashCooldown);
            _canDash = true;
            _dashCooldownCoroutine = null;
        }

        public void DashAttack()
        {
            if (!initialized || !_canDashAttack) return;

            if (_dashCoroutine != null)
            {
                StopCoroutine(_dashCoroutine);
                _dashCoroutine = null;
                IsDashing = false;

                if (_dashCooldownCoroutine != null) StopCoroutine(_dashCooldownCoroutine);
                _dashCooldownCoroutine = StartCoroutine(DashCooldownCoroutine());
            }

            if (_dashAttackCoroutine != null) return;


            _dashAttackCoroutine = StartCoroutine(DashAttackCoroutine());
        }

        private IEnumerator DashAttackCoroutine()
        {
            IsDashAttacking = true;
            _canDashAttack = false;
            IsMoving = false;

            Vector3 dashDirection = GetDashDirection();
            RotateTo(dashDirection);
            CreateEvents.ShowPoolingVfxEvent.Initialize(vfxDashAttackSO, owner.transform.position, owner.transform.rotation);
            createChannel.RaiseEvent(CreateEvents.ShowPoolingVfxEvent);
            _velocity = dashDirection * _dashAttackSpeed;

            yield return new WaitForSeconds(_dashAttackDuration);

            IsDashAttacking = false;
            _dashAttackCoroutine = null;

            Move(_lastMoveDirection);

            if (_dashAttackCooldownCoroutine != null) StopCoroutine(_dashAttackCooldownCoroutine);
            _dashAttackCooldownCoroutine = StartCoroutine(DashAttackCooldownCoroutine());
        }

        private IEnumerator DashAttackCooldownCoroutine()
        {
            yield return new WaitForSeconds(_dashAttackCooldown);
            _canDashAttack = true;
            _dashAttackCooldownCoroutine = null;
        }

        private Vector3 GetDashDirection()
        {
            Vector3 direction = new Vector3(_lastMoveDirection.x, 0, _lastMoveDirection.y);
            return direction;
        }

        private void OnMoveKeyInput(MoveKeyInputEvent args)
        {
            Move(args.direction);
        }

        private void OnDashKeyInput(DashKeyInputEvent args)
        {
            Dash();
        }

        private void OnDashAttackKeyInput(DashAttackKeyInputEvent args)
        {
            DashAttack();
        }
    }
}