using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(FlippingCell))]
public class FlipGridEditor : Editor
{
    private FlippingCell _grid;
    public void OnEnable()
    {
        _grid = (FlippingCell)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }
}
