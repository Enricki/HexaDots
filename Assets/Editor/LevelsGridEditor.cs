using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelsGrid))]
public class LevelsGridEditor : Editor
{
    private LevelsGrid _grid;
    public void OnEnable()
    {
        _grid = (LevelsGrid)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20);
        if (GUILayout.Button("Update Grid"))
        {
            _grid.UpdateGrid();
        }
    }
}