using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private bool _invertSprite;

    private Transform _object;

    private void Awake()
    {
        _object = GetComponentInParent<Transform>();
    }

    public void RotateSprite(Vector3 direction)
    {
        var _rightRotation = _invertSprite ? Quaternion.Euler(0, 180, 0) : Quaternion.Euler(0, 0, 0);
        var _leftRotation = _invertSprite ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);

        if (direction.x > 0)
        {
            _object.rotation = _rightRotation;
        }
        else if (direction.x < 0)
        {
            _object.rotation = _leftRotation;
        }
    }
}
