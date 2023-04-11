using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Point", menuName = "Point/Create Point")]
public class PointVisual : ScriptableObject // ������� Scriptable Objectom
{
    [SerializeField]
    private PointType _type;
    [SerializeField]
    private Sprite _sprite;

    public PointType Type { get => _type; }
    public Sprite Sprite { get => _sprite; }
}