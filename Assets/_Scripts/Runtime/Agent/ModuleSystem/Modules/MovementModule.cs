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

        public bool IsMoving { get => new Vector2(_velocity.x, _velocity.z) != Vector2.zero; }

        private CharacterController _controller;
        private float _speed = 5f;
        private Vector3 _velocity = Vector3.zero;

        private void FixedUpdate()
        {
            if (initialized)
                _controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            this._controller = GetComponent<CharacterController>();

            DebugLogger.ValidateObject(_controller);
            DebugLogger.ValidateObject(playerMoveInputChannel);

            playerMoveInputChannel.AddListener<PlayerMoveInputEvent>(OnPlayerMoveInput);
        }

        private void Move(Vector2 direction)
        {
            _velocity = new Vector3(direction.x, 0, direction.y) * _speed;
        }

        private void OnPlayerMoveInput(PlayerMoveInputEvent args)
        {
            Move(args.direction);
        }
    }
}

