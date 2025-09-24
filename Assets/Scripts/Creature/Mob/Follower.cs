using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _horizontalTreshold = 0.2f;

    private Creature _creature;
    private Player _target;

    private void Awake()
    {
        _creature = GetComponent<Creature>();
    }

    public void FollowTarget()
    {
        if (_target != null)
        {
            var horizontalDelta = Mathf.Abs(_target.transform.position.x - transform.position.x);
            Vector2 direction;

            if (horizontalDelta <= _horizontalTreshold)
            {
                direction = Vector2.zero;
            }
            else
            {
                direction = _target.transform.position - transform.position;
                direction.y = 0;
            }

            _creature.SetDirection(direction.normalized);
        }
    }

    public void RefreshTarget(Player player)
    {
        _target = player;
    }
}
