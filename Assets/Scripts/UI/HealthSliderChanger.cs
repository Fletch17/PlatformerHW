using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderChanger : UIHealthChanger
{
    protected Slider _slider;
    protected float _scaleDivision;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _scaleDivision = _slider.maxValue / _health.Max;
        _slider.value = _health.Current * _scaleDivision;
    }

    protected override void ChangeValue()
    {
        _slider.value = _health.Current * _scaleDivision;
    }
}
