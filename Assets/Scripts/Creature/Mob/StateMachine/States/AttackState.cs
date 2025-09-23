public class AttackState : State
{
    private Enemy _enemy;

    public AttackState(IStateChanger stateChanger, Enemy enemy):base(stateChanger)
    {
        _enemy = enemy;
    }       

    protected override void OnUpdate()
    {
        _enemy.Attack();
    }
}
