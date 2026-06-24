using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Core.ObjectPool.SO;
using Scripts.Core.Utilities;
using Scripts.Core.Utilities.SO;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using System.Collections;
using UnityEditor.U2D;
using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules
{
    public class MovementModule : AbstractModule, IMovable
    {
        [SerializeField] CharacterController controller;
        [SerializeField] private MovementModuleDataSO movementData;
        [SerializeField] private EventChannelSO pressKeyChannel;
        [SerializeField] private AssetNameSO vfxFootstepAssetNameSO;
        [SerializeField] private PoolItemSO vfxDashSO;

        public Vector2 LastMoveDirection { get; private set; }

        private VfxModule _vfxModule;
        private Coroutine _dashCoroutine;
        private Coroutine _dashCooldownCoroutine;

        private Vector3 _velocity = Vector3.zero;
        private float _moveSpeed = 0f;

        public bool IsMoving { get; private set; }

        private void FixedUpdate()
        {
            if (initialized)
                controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            if (movementData != null)          
                this._moveSpeed = movementData.MoveSpeed;

            DebugLogger.Assert(controller != null, "Controller is null");
            DebugLogger.Assert(pressKeyChannel != null, "PlayerMoveKeyInputChannel is null");
            DebugLogger.Assert(pressKeyChannel != null, "PlayerDashKeyInputChannel is null");
            DebugLogger.Assert(_vfxModule != null, "VfxModule is null");
            DebugLogger.Assert(vfxFootstepAssetNameSO != null, "VfxFootstepAssetNameSO is null");

            pressKeyChannel.AddListener<MoveKeyInputEvent>(OnMoveKeyInput);
        }

        private void Start()
        {
            _vfxModule?.StopVfx(vfxFootstepAssetNameSO.AssetNameHash);
        }

        public void Move(Vector2 direction)
        {
            LastMoveDirection = direction;

            if (IsDashing) return;

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

        public void SpeedUp(float speed) => _velocity *= speed;

        private void OnMoveKeyInput(MoveKeyInputEvent args)
        {
            Move(args.direction);
        }
    }
}