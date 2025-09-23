public class PatrolState : State
{
    private Enemy _enemy;

    public PatrolState(IStateChanger stateChanger, Enemy enemy) : base(stateChanger)
    {
        _enemy = enemy;
    }
    public override void Enter()
    {
        _enemy.StopRuning();
        _enemy.UpdateTime();
    }

    protected override void OnUpdate()
    {
        _enemy.Patrol();
    }
}
