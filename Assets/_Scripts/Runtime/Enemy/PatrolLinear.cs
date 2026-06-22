using UnityEngine;

namespace Runtime.Enemy
{
    public class PatrolLinear : MonoBehaviour
    {
        public Transform pointA;
        public Transform pointB;
        public float speed = 2.0f;

        void Update()
        {
            if (pointA == null || pointB == null) return;

            float timeValue = Mathf.PingPong(Time.time * speed, 1.0f);
            transform.position = Vector3.Lerp(pointA.position, pointB.position, timeValue);
        }
    }
}
