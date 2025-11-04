using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderChanger : UIHealthChanger
{
    protected Slider HealthSlider;
    protected float ScaleDivision;

    protected virtual void Start()
    {
        HealthSlider = GetComponent<Slider>();
        ScaleDivision = HealthSlider.maxValue / TargetHealthComponent.Max;
        HealthSlider.value = TargetHealthComponent.Current * ScaleDivision;
    }

    protected override void ChangeValue()
    {
        HealthSlider.value = TargetHealthComponent.Current * ScaleDivision;
    }
}
