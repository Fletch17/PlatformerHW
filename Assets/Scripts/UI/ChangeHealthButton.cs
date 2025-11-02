using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ChangeHealthButton : MonoBehaviour
{
    [SerializeField] private Health _healthComponent;
    [SerializeField] private int _damage = 1;
    private Button _currentButton;

    public Health HealthComponent => _healthComponent;
    public int Damage => _damage;

    private void Awake()
    {
        _currentButton = GetComponent<Button>();
    }

    protected void OnEnable()
    {
        _currentButton.onClick.AddListener(ChangePlayerHealth);
    }

    private void OnDisable()
    {
        _currentButton.onClick.RemoveListener(ChangePlayerHealth);
    }

    protected abstract void ChangePlayerHealth();
}
