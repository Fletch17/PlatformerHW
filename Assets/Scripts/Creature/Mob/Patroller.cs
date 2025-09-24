using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private LayerChecker _groundChecker;

    private Creature _creature;
    private float _directionX = 1;

    private void Awake()
    {
        _creature = GetComponent<Creature>();
    }

    public void Patrol()
    {
        if (!_groundChecker.IsTouching)
        {
            _directionX *= -1;
        }

        _creature.SetDirection(new Vector2(_directionX, 0));
    }
}
