using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int _healthPointCount;

    public int HealthPointCount => _healthPointCount;
}