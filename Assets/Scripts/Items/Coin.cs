using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _collider2D;

    private CoinAnimator _coinAnimator;

    private void Awake()
    {
        _coinAnimator = GetComponent<CoinAnimator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player hero))
        {
            _collider2D.enabled = false;
            _rigidbody2D.simulated = false;
            hero.IncreaseCoinCount(_value);
            _coinAnimator.PlayDestroyAnimation();          
        }
    }
}
