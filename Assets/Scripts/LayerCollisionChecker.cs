using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LayerCollisionChecker : MonoBehaviour
{
    [SerializeField] protected LayerMask LayerMask;

    protected Collider2D Collider2D;

    public event Action LayerTouched;

    public bool IsTouching { get; protected set; };

    private void Awake()
    {
        Collider2D = GetComponent<Collider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        IsTouching = Collider2D.IsTouchingLayers(LayerMask);

        if (IsTouching)
        {
            LayerTouched?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouching = Collider2D.IsTouchingLayers(LayerMask);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IsTouching = Collider2D.IsTouchingLayers(LayerMask);
    }
}
