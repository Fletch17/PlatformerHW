using UnityEngine;

[RequireComponent (typeof(Creature))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(EnemyStateMachineFactory))]
[RequireComponent(typeof(Follower))]
[RequireComponent(typeof(Patroller))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ColliderPlayerChecker _visionChecker;
    [SerializeField] private LayerChecker _attackChecker;
    [SerializeField] private float _alarmDelay = 1f;
    [SerializeField] private float _missHeroCooldown = 0.5f;

    private Follower _follower;
    private Patroller _patroller;
    private StateMachine _stateMachine;
    private Creature _creature;
    private Health _health;
    private float _time = -10f;

    public bool IsAlarmEnded => _time + _alarmDelay < Time.time;
    public bool IsHeroMiss => _time + _missHeroCooldown < Time.time;
    public bool CanAttack => _attackChecker.IsTouching;
    public bool IsPlayerDetected => _visionChecker.IsTouching;

    private void Awake()
    {
        _follower = GetComponent<Follower>();
        _patroller = GetComponent<Patroller>();
        _health = GetComponent<Health>();
        _creature = GetComponent<Creature>();
        _health = GetComponent<Health>();
        _stateMachine = GetComponent<EnemyStateMachineFactory>().Create(this);
    }

    private void OnEnable()
    {
        _health.Died += SetDeadStatus;
        _visionChecker.PlayerTouched += _follower.RefreshTarget;
    }

    private void Update()
    {
        _stateMachine?.Update();
    }

    private void OnDisable()
    {
        _health.Died -= SetDeadStatus;
        _visionChecker.PlayerTouched -= _follower.RefreshTarget;
    }

    public void Patrol()
    {
        if (IsHeroMiss)
        {
            _patroller.Patrol();
        }
    }     

    public void StopRunning()
    {
        _creature.SetDirection(Vector2.zero);
    }

    public void Attack()
    {
        StopRunning();
        _creature.Attack();
    }

    public void UpdateTime()
    {
        _time = Time.time;
    }

    public void FollowTarget()
    {
        if (IsAlarmEnded)
        {
            _follower.FollowTarget();
        }
    }

    private void SetDeadStatus()
    {
        StopRunning();
        _stateMachine.Stop();
        _stateMachine = null;
    }    
}
