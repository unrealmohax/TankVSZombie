using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _smoothSpeed = 1f;
    [SerializeField] private float _distanceFromTarget = 30f;

    public void SetTarget(Transform target) 
    {
        if(_target == null || target != null)
            _target = target;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 desiredPosition = _target.position - transform.forward * _distanceFromTarget;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

            transform.position = smoothedPosition;

            transform.LookAt(_target);
        }
    }
}