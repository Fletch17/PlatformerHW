using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _invertSprite;
    [SerializeField] private GroundChecker _groundChecker;

    protected bool _isGrounded;
    protected Vector2 _direction;
    protected Animator _animator;
    protected Health _health;

    private Attacker _attacker;
    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;
    private Collider2D _collider2D;

    private const string IsRunning = nameof(IsRunning);
    private const string IsOnGround = nameof(IsOnGround);
    private const string VerticalVelocity = nameof(VerticalVelocity);
    private const string OnAttack = nameof(OnAttack);
    private const string OnHit = nameof(OnHit);
    private const string IsDead = nameof(IsDead);

    protected virtual void Awake()
    {
        _attacker=GetComponent<Attacker>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rotator = GetComponent<Rotator>();
        _health = GetComponent<Health>();
        _animator= GetComponent<Animator>();
        _collider2D=GetComponent<Collider2D>();
    }

    protected virtual void OnEnable()
    {
        _health.OnHit += Hit;
        _health.OnDie += Die;
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

    protected virtual void Update()
    {
        _isGrounded = _groundChecker.IsGround;
    }

    protected virtual void OnDisable()
    {
        _health.OnHit -= Hit;
        _health.OnDie -= Die;
    }  

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    protected virtual float CalculateYVelocity()
    {
        return _rigidbody2D.velocity.y;
    }

    public void Attack()
    {
        if (_attacker.CanAttack)
        {
            _animator.SetTrigger(OnAttack);
            _attacker.Attack();
        }
    }

    private void Die()
    {
        _animator.SetBool(IsDead, true);
        _rigidbody2D.simulated = false;
        _collider2D.enabled = false;
    }

    private void Hit()
    {
        _animator.SetTrigger(OnHit);
    }
}
