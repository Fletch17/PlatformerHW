using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody2D;
    private bool _isJumping;
    private float _velocityYTreshold = 0.001f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public float CalculateYVelocity(Vector2 direction, bool isGrounded)
    {
        var yVelocity = _rigidbody2D.velocity.y;
        var isJumpPressing = direction.y > 0;

        if (isGrounded)
        {
            _isJumping = false;
        }

        if (isJumpPressing)
        {
            _isJumping = true;
            var isFalling = _rigidbody2D.velocity.y <= _velocityYTreshold;

            yVelocity = isFalling ? CalculateJumpVelocity(yVelocity, isGrounded) : yVelocity;
        }
        else if (_rigidbody2D.velocity.y > 0 && _isJumping)
        {
            yVelocity *= 0.5f;
        }

        return yVelocity;
    }

    public float CalculateJumpVelocity(float yVelocity, bool isGrounded)
    {      
        if (isGrounded)
        {
            yVelocity += _jumpPower;
        }

        return yVelocity;
    }
}
