using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDeadTransition : Transition
{
    private Enemy _enemy;

    public ToDeadTransition(DeadState nextState, Enemy enemy):base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsDead;
    }
}
