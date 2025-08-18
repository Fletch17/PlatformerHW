using UnityEngine;

public class Player : Creature
{    
    private int _coinCount;
           
    public void IncreaseCoinCount(int count)
    {
        _coinCount += count;
    }
    
}
