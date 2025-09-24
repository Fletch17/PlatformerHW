using System;
using UnityEngine;

public class PlayerCollisionChecker : LayerCollisionChecker
{
    public event Action<Player> PlayerTouched;
     
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        IsTouching = Collider2D.IsTouchingLayers(LayerMask);

        if (collision.TryGetComponent(out Player player))
        {
            PlayerTouched?.Invoke(player);
        }
    }    
}
