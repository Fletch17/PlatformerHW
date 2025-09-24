using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ItemAnimator : MonoBehaviour
{
    public static readonly int OnDestroy = Animator.StringToHash(nameof(OnDestroy));

    private Animator _animator;   

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDestroyAnimation()
    {
        _animator.SetTrigger(OnDestroy);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
