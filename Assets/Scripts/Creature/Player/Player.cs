using UnityEngine;

public class Player : Creature
{
    private int _coinCount;
    private Jumper _jumper;
    private PlayerInputReader _playerInputReader;

    protected override void Update()
    {
        base.Update();
        _direction = _playerInputReader.Direction;
    }

    protected override void Awake()
    {
        base.Awake();
        _playerInputReader = GetComponent<PlayerInputReader>();
        _jumper = GetComponent<Jumper>();
    }

    protected override float CalculateYVelocity()
    {
        return _jumper.CalculateYVelocity(_direction, _isGrounded);
    }

    public void IncreaseCoinCount(int count)
    {
        _coinCount += count;
    }

}
