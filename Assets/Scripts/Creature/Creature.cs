using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(CreatureAnimator))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rotator))]
public class Creature : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _invertSprite;
    [SerializeField] private GroundChecker _groundChecker;

    protected bool _isGrounded;
    protected Vector2 _direction;
    protected Health _health;

    private CreatureAnimator _creatureAnimator;
    private Attacker _attacker;
    private Rigidbody2D _rigidbody2D;
    private Rotator _rotator;
    private Collider2D _collider2D;      

    protected virtual void Awake()
    {
        _attacker=GetComponent<Attacker>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rotator = GetComponent<Rotator>();
        _health = GetComponent<Health>();
        _creatureAnimator = GetComponent<CreatureAnimator>();
        _collider2D =GetComponent<Collider2D>();
    }

    protected virtual void OnEnable()
    {
        _health.Hited += Hit;
        _health.Died += Die;
    }

    private void FixedUpdate()
    {
        _isGrounded = _groundChecker.IsGround;
        var xVelocity = _direction.x * _speed;
        var yVelocity = CalculateYVelocity();
        _rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);

        _creatureAnimator.PlayMovementAnimation(_direction.x != 0, _isGrounded, yVelocity);
        _rotator.RotateSprite(_direction);
    }

    protected virtual void OnDisable()
    {
        _health.Hited -= Hit;
        _health.Died -= Die;
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
            _creatureAnimator.PlayAttack();
            _attacker.Attack();
        }
    }

    private void Die()
    {
        _creatureAnimator.PlayDeath();
        _rigidbody2D.simulated = false;
        _collider2D.enabled = false;
    }

    private void Hit()
    {
        _creatureAnimator.PlayHit();
    }
}
