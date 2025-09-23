using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ColliderPlayerChecker _visionChecker;
    [SerializeField] private LayerChecker _attackChecker;
    [SerializeField] private float _horizontalTreshold = 0.2f;
    [SerializeField] private float _alarmDelay = 1f;
    [SerializeField] private float _missHeroCooldown = 0.5f;
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private LayerChecker _groundChecker;
    [SerializeField] private Player _player;

    private Creature _creature;
    private Health _health;
    private float _directionX = 1;
    private float _time = -10f;

    public bool IsDead { get; private set; }
    public bool IsAlarmEnded => _time + _alarmDelay < Time.time;
    public bool IsHeroMiss => _time + _missHeroCooldown < Time.time;
    public bool CanAttack => _attackChecker.IsTouching;
    public bool IsPlayerDetected => _visionChecker.IsTouching;

    private void Awake()
    {
        IsDead = false;
        _creature = GetComponent<Creature>();
        _health = GetComponent<Health>();
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this, _player);
    }

    private void OnEnable()
    {
        _health.OnDie += SetDeadStatus;
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    private void OnDisable()
    {
        _health.OnDie -= SetDeadStatus;
    }

    public void Patrol()
    {
        if (IsHeroMiss)
        {
            if (!_groundChecker.IsTouching)
            {
                _directionX *= -1;
            }

            _creature.SetDirection(new Vector2(_directionX, 0));
        }
    }

    private void SetDeadStatus()
    {
        IsDead = true;
        StopRuning();
        _stateMachine = null;
    }

    public void StopRuning()
    {
        _creature.SetDirection(Vector2.zero);
    }

    public void Attack()
    {
        StopRuning();
        _creature.Attack();
    }

    public void UpdateTime()
    {
        _time = Time.time;
    }

    public void FollowTarget(Player player)
    {
        if (IsAlarmEnded)
        {
            var horizontalDelta = Mathf.Abs(player.transform.position.x - transform.position.x);
            Vector2 direction;

            if (horizontalDelta <= _horizontalTreshold)
            {
                direction = Vector2.zero;
            }
            else
            {
                direction = player.transform.position - transform.position;
                direction.y = 0;
            }

            _creature.SetDirection(direction.normalized);
        }
    }
}
