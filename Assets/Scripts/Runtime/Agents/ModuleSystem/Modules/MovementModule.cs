using Scripts.Core.EventChannels;
using Scripts.Core.EventChannels.SO;
using Scripts.Core.Utilities;
using Scripts.Core.Utilities.SO;
using Scripts.Runtime.Agents.ModuleSystem.Modules.Interface;
using Scripts.Runtime.Agents.ModuleSystem.Modules.SO;

using UnityEngine;

namespace Scripts.Runtime.Agents.ModuleSystem.Modules
{
    public class MovementModule : AbstractModule, IMovementModule
    {
        [SerializeField] CharacterController controller;
        [SerializeField] private MovementModuleDataSO movementData;
        [SerializeField] private EventChannelSO pressKeyChannel;
        [SerializeField] private AssetNameSO vfxFootstepAssetNameSO;

        public bool CanMove { get; set; }
        public Vector2 LastMoveDirection { get; private set; }

        private IVfxModule _vfxModule;
        private ITriggerModule _triggerModule;
        private Vector3 _velocity = Vector3.zero;
        private float _moveSpeed = 0f;

        private void FixedUpdate()
        {
            if (initialized)
                controller.Move(_velocity * Time.fixedDeltaTime);
        }

        protected override void OnInitialize()
        {
            if (movementData != null)
                this._moveSpeed = movementData.MoveSpeed;
            this.CanMove = true;

            _vfxModule = owner.GetModule<IVfxModule>();
            _triggerModule = owner.GetModule<ITriggerModule>();

            DebugLogger.Assert(controller != null, "Controller is null");
            DebugLogger.Assert(pressKeyChannel != null, "PlayerMoveKeyInputChannel is null");
            DebugLogger.Assert(pressKeyChannel != null, "PlayerDashKeyInputChannel is null");
            DebugLogger.Assert(_vfxModule != null, "VfxModule is null");
            DebugLogger.Assert(vfxFootstepAssetNameSO != null, "VfxFootstepAssetNameSO is null");

            pressKeyChannel.AddListener<MoveKeyInputEvent>(HandleMoveKeyInput);
            _vfxModule?.StopVfx(vfxFootstepAssetNameSO.AssetNameHash);
        }

        public void Move(Vector2 direction)
        {
            LastMoveDirection = direction;

            if (!CanMove) return;

            _velocity = new Vector3(direction.x, 0, direction.y) * _moveSpeed;
            _triggerModule?.OnMoved();
            _vfxModule?.PlayVfx(vfxFootstepAssetNameSO.AssetNameHash);
            RotateTo(_velocity);
        }

        public void RotateTo(Vector3 direction)
        {
            if (direction.sqrMagnitude < Mathf.Epsilon) return;
            direction.y = 0;
            owner.transform.forward = direction.normalized;
        }

        public void SpeedUp(float speed) => _moveSpeed = speed;

        private void HandleMoveKeyInput(MoveKeyInputEvent args) => Move(args.Direction);
    }
}