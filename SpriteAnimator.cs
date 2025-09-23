using System;
using System.Collections;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Clip[] _clips;

    private int _currentClip;

    private IEnumerator _currentCoroutine;

    private const string Idle = nameof(Idle);

    private void Awake()
    {
        StartPlayClip(Idle);
    }

    private void OnBecameVisible()
    {
        _clips[_currentClip].StartPlay();
    }

    private void OnBecameInvisible()
    {
        _clips[_currentClip].StopPlay();
    }

    private void StartPlayClip(string name)
    {
        if (_clips != null)
        {
            for (int i = 0; i < _clips.Length; i++)
            {
                if (_clips[i].Name == name)
                {
                    _currentClip = i;
                    break;
                }
            }

            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }

            _currentCoroutine = _clips[_currentClip].Play();
            StartCoroutine(_currentCoroutine);
        }
    }
}

public class Clip:MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private bool _isLoop;
    [SerializeField] private int _frameRate;

    private bool _isPlaying;
    private int _currentFrame;
    private WaitForSeconds _secondsPerFrame;
    private SpriteRenderer _spriteRenderer;

    public string Name => _name;
    public Sprite[] Sprites => _sprites;
    public bool IsLoop => _isLoop;

    public event Action OnComplete;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator Play()
    {
        _secondsPerFrame = new WaitForSeconds(1 / _frameRate);

        while (_isPlaying)
        {
            if (_currentFrame >= Sprites.Length)
            {
                if (IsLoop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    OnComplete?.Invoke();
                }
            }

            _spriteRenderer.sprite = Sprites[_currentFrame];
            _currentFrame++;
            yield return _secondsPerFrame;
        }
    }

    public void StartPlay()
    {
        _isPlaying = true;
    }

    public void StopPlay() 
    {
        _isPlaying = false;
    }
}
