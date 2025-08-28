using System;
using UnityEngine;

public class ColliderPlayerChecker : LayerChecker
{
    public event Action<Player> PlayerTouched;
     
    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        _isTouching = _collider2D.IsTouchingLayers(_layerMask);

        if (collision.TryGetComponent(out Player player))
        {
            PlayerTouched?.Invoke(player);
        }
    }    
}
