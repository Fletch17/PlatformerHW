using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAgrToHeroTransition : Transition
{
    private Enemy _enemy;

    public ToAgrToHeroTransition(AgrToHeroState nextState, Enemy enemy) :base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsPlayerDetected;
    }
}
