public class AttackButton : ChangeHealthButton
{
    protected override void ChangePlayerHealth()
    {
        HealthComponent.Decrease(Damage);
    }
}
