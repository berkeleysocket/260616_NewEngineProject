using System.Collections;
using Core.Utilities;
using Core.Utilities.EventChannelSystem;
using Runtime.Agents.ModuleSystem.Interface;
using Runtime.Player;
using UnityEngine;

namespace Runtime.Agents.ModuleSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementModule : AbstractModule, IMovement
    {
        [SerializeField] private GameEventChannelSO playerMoveKeyInputChannel;
        [SerializeField] private GameEventChannelSO playerDashKeyInputChannel;
        [SerializeField] private GameEventChannelSO playerCompletedDashChannel;
        [SerializeField] private GameEventChannelSO playerIsDashingChannel;

        private CharacterController _controller;
        private PlayerCompletedDashEvent _playerCompletedDashEvent;
        private PlayerIsDashingEvent _playerIsDashingEvent;
        private Vector3 _velocity = Vector3.zero;
        private Vector2 _lastMoveInput = Vector2.zero; 
        private bool _canDash = true;
        private float _moveSpeed = 5f;
        private float _dashSpeed = 10f;      
        private float _dashDuration = 0.5f;  
        private float _dashCooldown = 1f;   

        public bool IsMoving { get; private set; }
        public bool IsDashing { get; private set; }


        private void FixedUpdate()
        {
            if (initialized)
                _controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            this._controller = GetComponent<CharacterController>();
            this._playerCompletedDashEvent = new PlayerCompletedDashEvent();
            this._playerIsDashingEvent = new PlayerIsDashingEvent();

            DebugLogger.Assert(_controller != null, "Controller is null");
            DebugLogger.Assert(playerMoveKeyInputChannel != null, "PlayerMoveKeyInputChannel is null");
            DebugLogger.Assert(playerDashKeyInputChannel != null, "PlayerDashKeyInputChannel is null");
            DebugLogger.Assert(playerCompletedDashChannel != null, "PlayerCompletedDashChannel is null");
            DebugLogger.Assert(playerIsDashingChannel != null, "PlayerIsDashingChannel is null");

            playerMoveKeyInputChannel.AddListener<PlayerMoveKeyInputEvent>(OnPlayerMoveKeyInput);
            playerDashKeyInputChannel.AddListener<PlayerDashKeyInputEvent>(OnPlayerDashKeyInput); 
        }

        private void Move(Vector2 direction)
        {
            _lastMoveInput = direction; 

            if (IsDashing) return;

            _velocity = new Vector3(direction.x, 0, direction.y) * _moveSpeed;
            RotateTo(_velocity);

            if (direction.x != 0f || direction.y != 0f)
                IsMoving = true;
            else
                IsMoving = false;
        }

        public void RotateTo(Vector3 direction)
        {
            if (direction.sqrMagnitude < Mathf.Epsilon) return;
            direction.y = 0;
            owner.transform.forward = direction.normalized;
        }

        public void Dash()
        {
            if (!initialized || IsDashing || !_canDash) return;

            playerIsDashingChannel.RaiseEvent(_playerIsDashingEvent);
            StartCoroutine(DashCoroutine());
        }

        private IEnumerator DashCoroutine()
        {
            IsDashing = true;
            _canDash = false;
            IsMoving = false; 

            Vector3 dashDirection = owner.transform.forward;
            dashDirection.y = 0;
            dashDirection.Normalize();

            if (dashDirection.sqrMagnitude < Mathf.Epsilon)
            {
                dashDirection = owner.transform.forward;
            }

            _velocity = dashDirection * _dashSpeed;

            yield return new WaitForSeconds(_dashDuration);

            IsDashing = false;
            playerCompletedDashChannel.RaiseEvent(_playerCompletedDashEvent);
            Move(_lastMoveInput);

            yield return new WaitForSeconds(_dashCooldown);
            _canDash = true;
        }

        private void OnPlayerMoveKeyInput(PlayerMoveKeyInputEvent args)
        {
            Move(args.direction);
        }

        private void OnPlayerDashKeyInput(PlayerDashKeyInputEvent args)
        {
            Dash();
        }
    }
}