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
        while (_slider.value != _health.Current * _scaleDivision)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Current * _scaleDivision, _speed * _scaleDivision);
            yield return null;
        }
    }
}
