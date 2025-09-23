using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private AttackChecker _attackChecker;

    private float _attackPause;
    private float _time;

    public bool CanAttack => _time + _attackPause < Time.time;

    private void Start()
    {
        _attackPause = 1f / _attackSpeed;
        _time = 0;
    }      

    public void Attack()
    {
        if (_attackChecker.TryCheckHealthComponent(out List<Health> healths))
        {
            foreach (Health health in healths)
            {
                health.Decrease(_damage);
            }
        }

        _time = Time.time;
    }
}
