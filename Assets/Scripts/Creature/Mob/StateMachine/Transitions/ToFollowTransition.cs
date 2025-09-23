public class ToFollowTransition : Transition
{
    private Enemy _enemy;

    public ToFollowTransition(FollowTargetState nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return (_enemy.IsPlayerDetected && !_enemy.CanAttack) == true;
    }
}
