using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    [SerializeField] private Patroling _patrolType;

    private Coroutine _currentState;

    private void Awake()
    {
        _currentState = StartCoroutine(_patrolType.Patrol());
    }
}
