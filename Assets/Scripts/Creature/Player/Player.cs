using UnityEngine;

public class Player : Creature
{
    [SerializeField] private ItemPeacker _itemPeacker;

    private CoinCounter _coinCounter;
    private Jumper _jumper;
    private PlayerInputReader _playerInputReader;

    protected override void Update()
    {
        base.Update();
        _direction = _playerInputReader.Direction;

        if (_playerInputReader.IsAttack)
        {
            Attack();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        _playerInputReader = GetComponent<PlayerInputReader>();
        _jumper = GetComponent<Jumper>();
        _coinCounter = GetComponent<CoinCounter>();
    }

    protected override void OnEnable()
    {
        _itemPeacker.CoinPeaked += _coinCounter.Increase;
        _itemPeacker.PotionPeaked += _health.Increase;
        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _itemPeacker.CoinPeaked -= _coinCounter.Increase;
        _itemPeacker.PotionPeaked -= _health.Increase;
        base.OnDisable();
    }

    protected override float CalculateYVelocity()
    {
        return _jumper.CalculateYVelocity(_direction, _isGrounded);
    }       
}
