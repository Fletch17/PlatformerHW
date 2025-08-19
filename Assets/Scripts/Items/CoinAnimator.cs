using System;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    private Animator _animator;

    private const string IsDestroy = nameof(IsDestroy);

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayDestroyAnimation()
    {
        _animator.SetBool(IsDestroy, true);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
