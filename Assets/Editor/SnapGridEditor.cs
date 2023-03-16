using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomSnapGrid))]
public class SnapGridEditor : Editor
{
    private CustomSnapGrid _grid;
    public void OnEnable()
    {
        _grid = (CustomSnapGrid)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20);
        if (GUILayout.Button("Generate Grid"))
        {
            _grid.GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            _grid.ClearGrid();
        }
    }
}


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
        GUILayout.Space(20);
        if (GUILayout.Button("Generate Grid"))
        {
            _grid.GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            _grid.ClearGrid();
        }
    }
}