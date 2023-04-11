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
    private PointVisual _visual;


    private SpriteRenderer _renderer;

    public PointType PointType { get => _pointType; }
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
    Displacing
}