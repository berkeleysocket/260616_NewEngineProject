using Runtime.Agents;
using UnityEngine;

public class AgentCamera : MonoBehaviour
{
    [SerializeField] private Transform target;   
    [SerializeField] private float smoothTime = 0.3f; 
    [SerializeField] private Vector3 offset;     

    private Vector3 _currentVelocity = Vector3.zero; 

    private void Start()
    {
        if (offset == Vector3.zero && target != null)
        {
            offset = transform.position - target.position;
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
    }
}