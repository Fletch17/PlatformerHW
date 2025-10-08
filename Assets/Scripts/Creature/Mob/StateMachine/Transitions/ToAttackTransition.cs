using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAttackTransition : Transition
{
    private Enemy _enemy;

    public ToAttackTransition(AttackState nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.CanAttack;
    }
}
