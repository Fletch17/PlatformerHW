using System.Collections.Generic;
using UnityEngine;

public class HealthGetter : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private int _arraySize = 5;

    public bool TryGetHealthComponent(out List<Health> healths)
    {
        bool isComponentExist = false;
        healths = new List<Health>();
        Collider2D[] result = new Collider2D[_arraySize];
        int size = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, result, _layerMask);

        for (int i = 0; i < size; i++)
        {
            if (result[i].TryGetComponent(out Health health))
            {
                healths.Add(health);
                isComponentExist = true;
            }
        }

        return isComponentExist;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
