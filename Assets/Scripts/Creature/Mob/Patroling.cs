using System.Collections;
using UnityEngine;

public class Patroling : MonoBehaviour
{
    [SerializeField] private Creature _creature;
    [SerializeField] private LayerChecker _groundChecker;

    private float _directionX = 1;

    public IEnumerator Patrol()
    {
        while (enabled)
        {
            if (!_groundChecker.IsTouching)
            {
                _directionX *= -1;
            }

            _creature.SetDirection(new Vector2(_directionX, 0));
            yield return null;
        }
    }
}
