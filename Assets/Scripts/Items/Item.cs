using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ItemAnimator))]
public class Item : MonoBehaviour
{  
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private ItemAnimator _itemAnimator;

    private void Awake()
    {
        _itemAnimator = GetComponent<ItemAnimator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    public void StartDestroy()
    {
        _collider2D.enabled = false;
        _rigidbody2D.simulated = false;
        _itemAnimator.PlayDestroyAnimation();
    }
}
