using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Point : MonoBehaviour, IPositional
{
    [SerializeField]
    private PointVisual _visual;

    private SpriteRenderer _renderer;
    private PointType _pointType;

    public PointType PointType { get => _pointType;}
    public PointVisual Visual { set => _visual = value; }
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        _renderer.sprite = _visual.Sprite;
        _renderer.color = _visual.Color;
        _pointType = _visual.Type;
    }

    private void OnValidate()
    {
        _renderer = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }
}
public enum PointType
{
    Open,
    Closed,
}