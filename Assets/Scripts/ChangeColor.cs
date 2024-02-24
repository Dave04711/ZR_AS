using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Renderer ren;
    private MaterialPropertyBlock mpb;
    private Callbacks callbacks;

    private const string colorProperty = "_Color"; //URP - _BaseColor

    [SerializeField] private Color normal, selected, onHit;

    private void Awake()
    {
        callbacks = GetComponent<Callbacks>();
    }

    private void Start()
    {
        mpb = new MaterialPropertyBlock();
        OnRelease();
        callbacks.OnClick += OnClick;
        callbacks.OnRelease += OnRelease;
        callbacks.OnHit += OnHit;
    }

    private void OnDisable()
    {
        OnRelease();
    }

    private void SetColor(ColorType _color)
    {
        ren.GetPropertyBlock(mpb);

        mpb.SetColor(colorProperty,
            _color switch
            {
                ColorType.Selected => selected,
                ColorType.OnHit => onHit,
                _ => normal
            });

        ren.SetPropertyBlock(mpb);
    }

    private void SetColor(ColorType _color, float _duration)
    {
        ren.GetPropertyBlock(mpb);
        Color previousColor = mpb.GetColor(colorProperty);

        mpb.SetColor(colorProperty,
            _color switch
            {
                ColorType.Selected => selected,
                ColorType.OnHit => onHit,
                _ => normal
            });

        ren.SetPropertyBlock(mpb);

        StartCoroutine(RestoreColor());

        IEnumerator RestoreColor()
        {
            yield return new WaitForSeconds(_duration);
            mpb.SetColor(colorProperty, previousColor);
            ren.SetPropertyBlock(mpb);
        }
    }

    private void OnHit() => SetColor(ColorType.OnHit, .2f);
    private void OnClick() => SetColor(ColorType.Selected);
    private void OnRelease() => SetColor(ColorType.Normal);

    public enum ColorType
    {
        Normal,
        Selected,
        OnHit
    }
}
