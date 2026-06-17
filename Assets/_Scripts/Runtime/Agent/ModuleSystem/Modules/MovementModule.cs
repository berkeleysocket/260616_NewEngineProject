using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using Runtime.Agents.ModuleSystem.Interface;
using Runtime.Agents.ModuleSystem.SO;
using Runtime.Player;

using System.Collections;
using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementModule : AbstractModule, IMovement
    {
        [SerializeField] private MovementModuleDataSO movementData;

        [Header("Subscribe Channels")]
        [SerializeField] private GameEventChannelSO moveKeyInputChannel;
        [SerializeField] private GameEventChannelSO dashKeyInputChannel;
        [SerializeField] private GameEventChannelSO dashAttackKeyInputChannel;

        [Header("Publish Channels")]
        [SerializeField] private GameEventChannelSO completedDashChannel;
        [SerializeField] private GameEventChannelSO isDashingChannel;
        [SerializeField] private GameEventChannelSO completedDashAttackChannel;
        [SerializeField] private GameEventChannelSO isDashAttackingChannel;

        private CharacterController _controller;

        private IsDashingEvent _isDashingEvent;
        private CompletedDashEvent _completedDashEvent;
        private IsDashAttackingEvent _isDashAttackingEvent;
        private CompletedDashAttackEvent _completedDashAttackEvent;

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
                _controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            this._controller = GetComponent<CharacterController>();

            this._isDashingEvent = new IsDashingEvent();
            this._completedDashEvent = new CompletedDashEvent();
            this._isDashAttackingEvent = new IsDashAttackingEvent();
            this._completedDashAttackEvent = new CompletedDashAttackEvent();

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

            DebugLogger.Assert(_controller != null, "Controller is null");
            DebugLogger.Assert(moveKeyInputChannel != null, "PlayerMoveKeyInputChannel is null");
            DebugLogger.Assert(dashKeyInputChannel != null, "PlayerDashKeyInputChannel is null");
            DebugLogger.Assert(completedDashChannel != null, "PlayerCompletedDashChannel is null");
            DebugLogger.Assert(isDashingChannel != null, "PlayerIsDashingChannel is null");
            DebugLogger.Assert(completedDashAttackChannel != null, "PlayerCompletedDashAttackChannel is null");
            DebugLogger.Assert(isDashAttackingChannel != null, "PlayerIsDashAttackingChannel is null");

            moveKeyInputChannel.AddListener<MoveKeyInputEvent>(OnMoveKeyInput);
            dashKeyInputChannel.AddListener<DashKeyInputEvent>(OnDashKeyInput);
            dashAttackKeyInputChannel.AddListener<DashAttackKeyInputEvent>(OnDashAttackKeyInput);
        }

        private void Move(Vector2 direction)
        {
            _lastMoveDirection = direction;

            if (IsDashing || IsDashAttacking) return;

            _velocity = new Vector3(direction.x, 0, direction.y) * _moveSpeed;
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
                completedDashAttackChannel.RaiseEvent(_completedDashAttackEvent);

                if (_dashAttackCooldownCoroutine != null) StopCoroutine(_dashAttackCooldownCoroutine);
                _dashAttackCooldownCoroutine = StartCoroutine(DashAttackCooldownCoroutine());
            }

            if (_dashCoroutine != null) return;

            isDashingChannel.RaiseEvent(_isDashingEvent);
            _dashCoroutine = StartCoroutine(DashCoroutine());
        }

        private IEnumerator DashCoroutine()
        {
            IsDashing = true;
            _canDash = false;
            IsMoving = false;

            //Vector3 dashDirection = GetDashDirection();
            _velocity = _lastMoveDirection * _dashSpeed;

            yield return new WaitForSeconds(_dashDuration);

            IsDashing = false;
            completedDashChannel.RaiseEvent(_completedDashEvent);
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
                completedDashChannel.RaiseEvent(_completedDashEvent);

                if (_dashCooldownCoroutine != null) StopCoroutine(_dashCooldownCoroutine);
                _dashCooldownCoroutine = StartCoroutine(DashCooldownCoroutine());
            }

            if (_dashAttackCoroutine != null) return;

            isDashAttackingChannel.RaiseEvent(_isDashAttackingEvent);
            _dashAttackCoroutine = StartCoroutine(DashAttackCoroutine());
        }

        private IEnumerator DashAttackCoroutine()
        {
            IsDashAttacking = true;
            _canDashAttack = false;
            IsMoving = false;

            Vector3 dashDirection = GetDashDirection();
            _velocity = dashDirection * _dashAttackSpeed;

            yield return new WaitForSeconds(_dashAttackDuration);

            IsDashAttacking = false;
            completedDashAttackChannel.RaiseEvent(_completedDashAttackEvent);
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
            Vector3 direction = owner.transform.forward;
            direction.y = 0;
            direction.Normalize();

            if (direction.sqrMagnitude < Mathf.Epsilon)
            {
                direction = owner.transform.forward;
            }
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