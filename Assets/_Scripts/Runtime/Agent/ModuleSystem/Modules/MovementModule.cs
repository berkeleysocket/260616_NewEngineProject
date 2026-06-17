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
        [SerializeField] private GameEventChannelSO playerMoveInputChannel;
        [SerializeField] private GameEventChannelSO playerDashInputChannel;

        public bool IsMoving { get; private set; }
        public bool IsDashing { get; private set; }

        private CharacterController _controller;
        private float _moveSpeed = 5f;
        private float _rotationSpeed = 5f;
        private Vector3 _velocity = Vector3.zero;

        private void FixedUpdate()
        {
            if (initialized)
                _controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            this._controller = GetComponent<CharacterController>();

            DebugLogger.Assert(_controller != null, "Controller is null");
            DebugLogger.Assert(playerMoveInputChannel != null, "PlayerMoveInputChannel is null");
            DebugLogger.Assert(playerDashInputChannel != null, "PlayerDashInputChannel is null");

            playerMoveInputChannel.AddListener<PlayerMoveInputEvent>(OnPlayerMoveInput);
        }

        private void Move(Vector2 direction)
        {
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

        private void OnPlayerMoveInput(PlayerMoveInputEvent args)
        {
            Move(args.direction);
        }
    }
}

