using Runtime.Agents.ModuleSystem;
using Runtime.Agents.ModuleSystem.Interface;
using UnityEngine;

namespace Runtime.Enemy
{
    public class PatrolModule : AbstractModule, IPlayerMovementModule
    {
        [SerializeField] private Vector3 pointA;
        [SerializeField] private Vector3 pointB;
        [SerializeField] private float speed = 2.0f;

        public bool IsMoving => throw new System.NotImplementedException();

        public bool IsDashAttacking => throw new System.NotImplementedException();

        protected override void OnInitialize()
        {
            throw new System.NotImplementedException();
        }

        void Update()
        {
            if (pointA == null || pointB == null) return;

            float timeValue = Mathf.PingPong(Time.time * speed, 1.0f);
            transform.position = Vector3.Lerp(pointA, pointB, timeValue);
        }
    }
}
