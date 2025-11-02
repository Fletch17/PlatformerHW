using UnityEngine;

public abstract class UIHealthChanger : MonoBehaviour
{
    [SerializeField] protected Health _health;
   
   private void OnEnable()
    {
        _health.Healed += ChangeValue;
        _health.Hited += ChangeValue;
    }

    private void OnDisable()
    {
        _health.Healed -= ChangeValue;
        _health.Hited -= ChangeValue;
    }

    protected abstract void ChangeValue();
}
