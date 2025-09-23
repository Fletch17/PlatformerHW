using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;

    private void LateUpdate()
    {
        var newPosition = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }
}
