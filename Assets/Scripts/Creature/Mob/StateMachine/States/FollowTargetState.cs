public class FollowTargetState : State
{
    private Enemy _enemy;
    private Player _player;

    public FollowTargetState(IStateChanger stateChanger, Enemy enemy, Player player): base(stateChanger)
    {
        _enemy = enemy;
        _player = player;
    }

    public override void Enter()
    {
        _enemy.StopRuning();
        _enemy.UpdateTime();
    }

    protected override void OnUpdate()
    {        
        _enemy.FollowTarget(_player);
    }
}
