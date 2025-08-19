using UnityEngine;

public class LayerChecker : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;

    private Collider2D _collider2D;

    public bool IsTouching {  get; private set; }

    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTouching = _collider2D.IsTouchingLayers(_layerMask);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouching = _collider2D.IsTouchingLayers(_layerMask);
    }
}
