public class AttackButton : ChangeHealthButton
{
   protected override void OnEnable()
    {
        CurrentButton.onClick.AddListener(() => HealthComponent.Decrease(Damage));
    }
}
