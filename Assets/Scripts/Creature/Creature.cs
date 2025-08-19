using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    [SerializeField] private float _speed;
    [SerializeField] private bool _invertSprite;
    [SerializeField] private LayerChecker _groundChecker;

    protected bool _isGrounded;
    protected Vector2 _direction;

    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;    

    private const string IsRunning = nameof(IsRunning);
    private const string IsOnGround = nameof(IsOnGround);
    private const string VerticalVelocity = nameof(VerticalVelocity);

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rotator = GetComponent<Rotator>();
    }

    protected virtual void Update()
    {
        _isGrounded = _groundChecker.IsTouching;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    protected virtual float CalculateYVelocity()
    {
        return _rigidbody2D.velocity.y;
    }

    private void FixedUpdate()
    {        
        var xVelocity = _direction.x * _speed;
        var yVelocity = CalculateYVelocity();
        _rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);

        _animator.SetBool(IsRunning, _direction.x != 0);
        _animator.SetBool(IsOnGround, _isGrounded);
        _animator.SetFloat(VerticalVelocity, yVelocity);

        _rotator.RotateSprite(_direction);
    }    
}
