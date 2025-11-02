using TMPro;
using UnityEngine;

public class HealthTextChanger : UIHealthChanger
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        ChangeValue();
    }

    protected override void ChangeValue()
    {
        _text.text = $"{_health.Current}/{_health.Max}";
    }
}
