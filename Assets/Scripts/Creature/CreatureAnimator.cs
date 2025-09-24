using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CreatureAnimator : MonoBehaviour
{
    public static readonly int IsRunning = Animator.StringToHash(nameof(IsRunning));
    public static readonly int IsOnGround = Animator.StringToHash(nameof(IsOnGround));
    public static readonly int VerticalVelocity = Animator.StringToHash(nameof(VerticalVelocity));
    public static readonly int OnAttack = Animator.StringToHash(nameof(OnAttack));
    public static readonly int OnHit = Animator.StringToHash(nameof(OnHit));
    public static readonly int IsDead = Animator.StringToHash(nameof(IsDead));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayMovementAnimation(bool isRunning, bool isGrounded, float yVelocity)
    {
        _animator.SetBool(IsRunning, isRunning);
        _animator.SetBool(IsOnGround, isGrounded);
        _animator.SetFloat(VerticalVelocity, yVelocity);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(OnAttack);
    }

    public void PlayDeath()
    {
        _animator.SetBool(IsDead, true);
    }

    public void PlayHit()
    {
        _animator.SetTrigger(OnHit);
    }
}
