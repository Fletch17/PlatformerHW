public class AgrToHeroState : State
{
    private Enemy _enemy;

    public AgrToHeroState(IStateChanger stateChanger, Enemy enemy) : base(stateChanger)
    {
        _enemy = enemy;
    }

    protected override void OnUpdate()
    {
        _enemy.StopRuning();
    }
}
