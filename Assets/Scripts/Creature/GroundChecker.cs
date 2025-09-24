using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerMask;

    private RaycastHit2D[] _results=new RaycastHit2D[5];
    private float _distance = 0;

    public bool IsGround => Physics2D.CircleCastNonAlloc(transform.position, _radius, Vector2.down, _results, _distance, _layerMask) > 0;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
