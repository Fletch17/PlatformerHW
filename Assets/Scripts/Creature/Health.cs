using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max;

    private int _current;

    public event Action OnHit;
    public event Action OnDie;

    private void Awake()
    {
        _current = _max;
    }

    public void Increase(int health)
    {
        _current += health;

        if (_current > _max)
        {
            _current = _max;
        }

        Debug.Log(gameObject+": Increase. Curr: " +_current);
    }

    public void Decrease(int health)
    {
        _current -= health;
        OnHit?.Invoke();

        if (_current <= 0)
        {
            _current = 0;
            OnDie?.Invoke();
        }

        Debug.Log(gameObject + ": Decrease. Curr: " + _current);
    }
}
