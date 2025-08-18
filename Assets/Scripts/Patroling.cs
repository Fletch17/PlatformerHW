using System.Collections;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private Creature _creature;
    [SerializeField] private LayerCheck _groundCheck;

    private float _directionX = 1;

    public IEnumerator Patrol()
    {
        while (enabled)
        {
            if (!_groundCheck.IsTouching)
            {
                _directionX *= -1;
            }
            _creature.SetDirection(new Vector2(_directionX, 0));

            yield return new WaitForFixedUpdate();
        }
    }
}
