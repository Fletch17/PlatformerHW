using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] protected Animator _animator;
    [SerializeField] private float _jumpPower;
    [SerializeField] private LayerCheck _groundCheck;
    [SerializeField] private bool _isFlipX;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private static readonly int IsRunning = Animator.StringToHash("is-running");
    private static readonly int IsGround = Animator.StringToHash("is-ground");
    private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        var xVelocity = _direction.x * _speed;
        var yVelocity = CalculateYVelocity();
        _rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
        
        _animator.SetBool(IsRunning, _direction.x != 0);
        _animator.SetBool(IsGround, _isGrounded);
        _animator.SetFloat(VerticalVelocity, yVelocity);

        UpdateSpriteDirection(_direction);
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private float CalculateYVelocity()
    {
        var yVelocity = _rigidbody2D.velocity.y;

        if (_isGrounded && _direction.y > 0)
        {
            yVelocity += _jumpPower;
        }        

        return yVelocity;
    }

    private void UpdateSpriteDirection(Vector3 direction)
    {
        var koefficient = _isFlipX ? -1 : 1;

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(koefficient, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1* koefficient, 1, 1);
        }
    }
    private void Update()
    {
        _isGrounded = _groundCheck.IsTouching;
    }
}
