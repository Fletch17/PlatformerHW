using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private bool _invertSprite;
    
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
