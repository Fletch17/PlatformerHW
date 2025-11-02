using TMPro;
using UnityEngine;

public class HealthTextChanger : MonoBehaviour
{
    [SerializeField] private Health _health;
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        UpdateHealthText();
    }

    private void OnEnable()
    {
        _health.Hited += UpdateHealthText;
        _health.Healed += UpdateHealthText;
    }

    private void OnDisable()
    {
        _health.Hited -= UpdateHealthText;
        _health.Healed -= UpdateHealthText;
    }

    private void UpdateHealthText()
    {
        _text.text = $"{_health.Current}/{_health.Max}";
    }
}
