using UnityEngine;

namespace Runtime.Player
{
    public class SmoothCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime = 0.3f;

        private Vector3 _currentVelocity = Vector3.zero;
        private Vector3 _offset = Vector3.zero;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            if (target != null)
                _offset = transform.position - target.position;
        }

        private void LateUpdate()
        {
            if (target == null) return;

            Vector3 targetPosition = target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
    }
}
