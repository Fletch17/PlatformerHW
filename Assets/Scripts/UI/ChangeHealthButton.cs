using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ChangeHealthButton : MonoBehaviour
{
    [SerializeField] private Health _healthComponent;
    [SerializeField] private int _damage = 1;

    public Health HealthComponent => _healthComponent;
    public int Damage => _damage;

    public Button CurrentButton { get; protected set; }

    private void Awake()
    {
        CurrentButton = GetComponent<Button>();
    }

    protected abstract void OnEnable();

    private void OnDisable()
    {
        CurrentButton.onClick.RemoveAllListeners();
    }
}
