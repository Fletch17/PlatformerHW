using System.Collections;
using UnityEngine;

public class SmoothHealthSliderChanger : HealthSliderChanger
{
    [SerializeField] private float _speed;

    private IEnumerator _currentCoroutine;

    protected override void ChangeValue()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = ChangeSliderValue();
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator ChangeSliderValue()
    {
        while (HealthSlider.value != TargetHealthComponent.Current * ScaleDivision)
        {
            HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, TargetHealthComponent.Current * ScaleDivision, _speed * ScaleDivision);
            yield return null;
        }
    }
}
