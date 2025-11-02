using UnityEngine;
using UnityEngine.UI;

public class HealthSliderChanger : MonoBehaviour
{
    [SerializeField] protected Health _health;
    protected Slider _slider;
    protected float _scaleDivision;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _scaleDivision = _slider.maxValue / _health.Max;
        _slider.value = _health.Current * _scaleDivision;
    }

    protected virtual void OnEnable()
    {
        _health.Healed += ChangeValue;
        _health.Hited += ChangeValue;
    }

    protected virtual void OnDisable()
    {
        _health.Healed -= ChangeValue;
        _health.Hited -= ChangeValue;
    }

    private void ChangeValue()
    {
        _slider.value = _health.Current * _scaleDivision;
    }
}
