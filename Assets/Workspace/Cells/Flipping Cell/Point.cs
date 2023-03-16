using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Point : MonoBehaviour, IPositional
{
    [SerializeField]
    private PointType _pointType;
    [Space(60)]
    [SerializeField]
    private List<pointVisual> _visuals;


    private SpriteRenderer _renderer;

    public PointType PointerType { get => _pointType; }
    public Vector3 GetPosition()
    {
        return transform.localPosition;
    }

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        UpdateVisual(_pointType);
    }

    private void UpdateVisual(PointType type)
    {
        if (type == _visuals[0].Type)
        {
            _renderer.sprite = _visuals[0].Sprite;
        }
        if (type == _visuals[1].Type)
        {
            _renderer.sprite = _visuals[1].Sprite;
        }
    }

    private void OnValidate()
    {
        _renderer = GetComponent<SpriteRenderer>();
        UpdateVisual(_pointType);
    }
}
public enum PointType
{
    Open,
    Closed,
    Displacing
}

[Serializable]
public struct pointVisual // Сделать Scriptable Objectom
{
    [SerializeField]
    private PointType _type;
    [SerializeField]
    private Sprite _sprite;

    public PointType Type { get => _type; }
    public Sprite Sprite { get => _sprite; }
}