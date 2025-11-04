using UnityEngine;

public abstract class UIHealthChanger : MonoBehaviour
{
    [SerializeField] protected Health TargetHealthComponent;

    protected virtual void OnEnable()
    {
        TargetHealthComponent.Healed += ChangeValue;
        TargetHealthComponent.Hited += ChangeValue;
    }

    protected virtual void OnDisable()
    {
        TargetHealthComponent.Healed -= ChangeValue;
        TargetHealthComponent.Hited -= ChangeValue;
    }

    protected abstract void ChangeValue();
}
