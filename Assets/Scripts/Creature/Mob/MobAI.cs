using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private Patroling _patrolType;
    [SerializeField] private ColliderPlayerChecker _visionChecker;
    [SerializeField] private LayerChecker _attackChecker;
    [SerializeField] private float _horizontalTreshold = 0.2f;
    [SerializeField] private float _alarmDelay = 1f;
    [SerializeField] private float _missHeroCooldown = 0.5f;

    private IEnumerator _currentState;
    private Creature _creature;
    private Player _player;
    private Health _health;
    private bool _isDead;

    private void Awake()
    {
        _isDead = false;
        _creature = GetComponent<Creature>();
        _health = GetComponent<Health>();
        _currentState = _patrolType.Patrol();
        ChangeState(_currentState);
    }

    private void OnEnable()
    {
        _visionChecker.PlayerTouched += SetTargetToAgr;
        _health.OnDie += SetDeadStatus;
    }

    private void OnDisable()
    {
        _visionChecker.PlayerTouched -= SetTargetToAgr;
        _health.OnDie -= SetDeadStatus;
    }

    private void SetDeadStatus()
    {
        _isDead = true;

        if (_currentState != null)
        {
            StopCoroutine(_currentState);
        }
    }

    private void ChangeState(IEnumerator coroutine)
    {
        _creature.SetDirection(Vector2.zero);

        if (_currentState != null)
        {
            StopCoroutine(_currentState);
        }

        _currentState = coroutine;
        StartCoroutine(coroutine);
    }

    private void SetTargetToAgr(Player player)
    {
        _player = player;
        ChangeState(AgroToHero());
    }

    private IEnumerator Attack()
    {
        while (_attackChecker.IsTouching)
        {
            _creature.Attack();
            yield return null;
        }

        ChangeState(FollowTarget());
    }

    private IEnumerator FollowTarget()
    {
        while (_visionChecker.IsTouching)
        {
            if (_attackChecker.IsTouching)
            {
                ChangeState(Attack());
            }
            else
            {
                var horizontalDelta = Mathf.Abs(_player.transform.position.x - transform.position.x);
                Vector2 direction;

                if (horizontalDelta <= _horizontalTreshold)
                {
                    direction = Vector2.zero;
                }
                else
                {
                    direction = _player.transform.position - transform.position;
                    direction.y = 0;
                }

                _creature.SetDirection(direction.normalized);
            }

            yield return null;
        }

        if (!_isDead)
        {
            _creature.SetDirection(Vector2.zero);
            yield return new WaitForSeconds(_missHeroCooldown);
            ChangeState(_patrolType.Patrol());
        }
    }

    private IEnumerator AgroToHero()
    {
        _creature.SetDirection(Vector2.zero);
        yield return new WaitForSeconds(_alarmDelay);
        ChangeState(FollowTarget());
    }
}
