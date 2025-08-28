using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event Action OnHit;
    public event Action OnDie;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Increase(int health)
    {
        _currentHealth += health;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        Debug.Log(gameObject+": Increase. Curr: " +_currentHealth);
    }

    public void Decrease(int health)
    {
        _currentHealth -= health;
        OnHit?.Invoke();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDie?.Invoke();
        }

        Debug.Log(gameObject + ": Decrease. Curr: " + _currentHealth);
    }
}
