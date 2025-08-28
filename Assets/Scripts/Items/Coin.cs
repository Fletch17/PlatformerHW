using UnityEngine;

public class Coin : Item
{
    [SerializeField] public int _value;    

    public int Value => _value;
}
