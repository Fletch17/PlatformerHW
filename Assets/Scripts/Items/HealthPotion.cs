using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int _hpCount;

    public int HpCount => _hpCount;
}
