using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthEnemySliderChanger : SmoothHealthSliderChanger
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private Image _backgroundImage;

    private Color _invisibleColor = new Color(0, 0, 0, 0);
    private Color _backgroundColor;

    protected override void Start()
    {
        base.Start();
        _backgroundColor = _backgroundImage.color;
        ChangeImagesColor(_invisibleColor, _invisibleColor);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        TargetHealthComponent.Healed += ChangeColor;
        TargetHealthComponent.Hited += ChangeColor;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        TargetHealthComponent.Healed -= ChangeColor;
        TargetHealthComponent.Hited -= ChangeColor;
    }

    private void ChangeColor()
    {
        if (TargetHealthComponent.Max == TargetHealthComponent.Current)
        {
            ChangeImagesColor(_invisibleColor, _invisibleColor);
        }
        else
        {
            ChangeImagesColor(Color.red, _backgroundColor);
        }
    }

    private void ChangeImagesColor(Color fillColor, Color backgroundColor)
    {
        _fillImage.color = fillColor;
        _backgroundImage.color = backgroundColor;
    }
}
