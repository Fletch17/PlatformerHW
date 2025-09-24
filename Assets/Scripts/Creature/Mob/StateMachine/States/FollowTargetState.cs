public class FollowTargetState : State
{
    private Enemy _enemy;

    public FollowTargetState(IStateChanger stateChanger, Enemy enemy): base(stateChanger)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        _enemy.StopRunning();
        _enemy.UpdateTime();
    }

    protected override void OnUpdate()
    {        
        _enemy.FollowTarget();
    }
}
