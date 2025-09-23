public class ToPatrolTransition : Transition
{
    private Enemy _enemy;

    public ToPatrolTransition(PatrolState nextState, Enemy enemy) : base(nextState)
    {
        _enemy = enemy;
    }

    protected override bool CanTransit()
    {
        return _enemy.IsPlayerDetected == false;
    }
}
