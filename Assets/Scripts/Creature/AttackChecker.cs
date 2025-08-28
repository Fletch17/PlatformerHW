using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _attackSpeed;

    private int _arraySize = 5;
    private float _attackPause;
    private float _time;

    public bool CanAttack { get; private set; }

    private void Start()
    {
        _attackPause = 1f / _attackSpeed;
        _time = 0;
    }

    private void Update()
    {
        if (_time >= _attackPause)
        {
            CanAttack = true;
        }
        else
        {
            _time += Time.deltaTime;
            CanAttack = false;
        }
    }

    public void Attack()
    {
        Collider2D[] result = new Collider2D[_arraySize];
        int size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, result, _layerMask);

        for (int i = 0; i < size; i++)
        {
            if (result[i].TryGetComponent(out Health health))
            {
                health.Decrease(_damage);
            }
        }

        CanAttack = false;
        _time = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
