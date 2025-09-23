using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAttackTransition : Transition
{
    private Enemy _enemy;
   // private Player _player;

    public ToAttackTransition(AttackState nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
       // _player = player;
    }

    protected override bool CanTransit()
    {
        return _enemy.CanAttack;
    }
}
