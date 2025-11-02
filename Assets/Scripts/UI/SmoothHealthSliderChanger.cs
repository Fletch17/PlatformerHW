using System.Collections;
using UnityEngine;

public class SmoothHealthSliderChanger : HealthSliderChanger
{
    [SerializeField] private float _speed;

    private IEnumerator _currentCoroutine;

    protected override void OnEnable()
    {
        _health.Healed += StartChange;
        _health.Hited += StartChange;
    }

    protected override void OnDisable()
    {
        _health.Healed -= StartChange;
        _health.Hited -= StartChange;
    }

    private void StartChange()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = ChangeValue();
        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator ChangeValue()
    {
        while (_slider.value != _health.Current * _scaleDivision)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.Current * _scaleDivision, _speed * _scaleDivision);
            yield return null;
        }
    }
}
