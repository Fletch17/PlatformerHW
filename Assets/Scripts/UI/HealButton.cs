public class HealButton : ChangeHealthButton
{
    protected override void ChangePlayerHealth()
    {
        HealthComponent.Increase(Damage);
    }
}
