using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ItemAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string OnDestroy = nameof(OnDestroy);

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
