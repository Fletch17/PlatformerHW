using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void OnMovement(InputValue contex)
    {
        var direction = contex.Get<Vector2>();
        _player.SetDirection(direction);
    }
}
