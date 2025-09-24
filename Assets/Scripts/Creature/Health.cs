using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _max;

    private int _current;

    public event Action Hited;
    public event Action Died;

    private void Awake()
    {
        _current = _max;
    }

    public void Increase(int health)
    {
        _current += Math.Abs(health);

        if (_current > _max)
        {
            _current = _max;
        }

        Debug.Log(gameObject+": Increase. Curr: " +_current);
    }

    public void Decrease(int health)
    {
        _current -= Math.Abs(health);
        Hited?.Invoke();

        if (_current <= 0)
        {
            _current = 0;
            Died?.Invoke();
        }

        Debug.Log(gameObject + ": Decrease. Curr: " + _current);
    }
}
