using System;
using UnityEngine;

public class LayerChecker : MonoBehaviour
{
    [SerializeField] protected LayerMask _layerMask;

    protected Collider2D _collider2D;
    protected bool _isTouching;

    public event Action LayerTouched;

    public bool IsTouching => _isTouching;

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        _isTouching = _collider2D.IsTouchingLayers(_layerMask);

        if (IsTouching)
        {
            LayerTouched?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isTouching = _collider2D.IsTouchingLayers(_layerMask);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isTouching = _collider2D.IsTouchingLayers(_layerMask);
    }
}
