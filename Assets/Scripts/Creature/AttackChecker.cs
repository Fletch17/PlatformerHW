using System.Collections.Generic;
using UnityEngine;

public class AttackChecker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private int _arraySize = 5;

    public bool TryCheckHealthComponent(out List<Health> healths)
    {
        healths = new List<Health>();
        Collider2D[] result = new Collider2D[_arraySize];
        int size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, result, _layerMask);

        for (int i = 0; i < size; i++)
        {
            if (result[i].TryGetComponent(out Health health))
            {
                healths.Add(health);
            }
        }

        if (healths.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
