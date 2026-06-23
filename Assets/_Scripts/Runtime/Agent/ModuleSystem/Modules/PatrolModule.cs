using Core.Utilities;
using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;

using UnityEngine;

namespace Runtime.Enemy
{
    public class PatrolModule : AbstractModule, IEnemyMovementModule
    {
        [SerializeField] private Transform body;
        [SerializeField] private Vector3 pointA;
        [SerializeField] private Vector3 pointB;
        [SerializeField] private float speed = 2.0f;

        public bool IsMoving => _isMoving;
        private bool _isMoving = false;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(pointA, 0.25f);
            Gizmos.DrawSphere(pointB, 0.25f);
            Gizmos.DrawLine(pointA, pointB);
        }

        private void Update()
        {
            if (pointA == pointB || _isMoving == false) return;

            float timeValue = Mathf.PingPong(Time.time * speed, 1.0f);
            body.localPosition = Vector3.Lerp(pointA, pointB, timeValue);
        }

        protected override void OnInitialize()
        {
            _isMoving = true;

            DebugLogger.Assert(body != null, "body is null");
        }
    }
}