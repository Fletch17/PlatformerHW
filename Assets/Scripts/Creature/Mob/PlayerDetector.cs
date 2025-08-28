using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public event Action<Player> PlayerDetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            PlayerDetected?.Invoke(player);
        }
    }
}
