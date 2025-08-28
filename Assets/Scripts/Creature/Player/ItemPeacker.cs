using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPeacker : MonoBehaviour
{
    public event Action<int> CoinPeaked;
    public event Action<int> PotionPeaked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            CoinPeaked?.Invoke(coin.Value);
            coin.StartDestroy();
        }
        else if (collision.TryGetComponent(out HealthPotion healthPotion))
        {
            PotionPeaked?.Invoke(healthPotion.HpCount);
            healthPotion.StartDestroy();
        }
    }
}
