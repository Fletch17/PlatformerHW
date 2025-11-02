public class HealButton : ChangeHealthButton
{
    protected override void OnEnable()
    {
        CurrentButton.onClick.AddListener(() => HealthComponent.Increase(Damage));
    }
}
