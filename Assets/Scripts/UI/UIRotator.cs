using UnityEngine;

public class UIRotator : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}
