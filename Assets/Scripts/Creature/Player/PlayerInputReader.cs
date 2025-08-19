using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private Vector2 _direction;

    public Vector2 Direction => _direction;

    public void OnMovement(InputValue contex)
    {
        _direction= contex.Get<Vector2>();
    }
}
