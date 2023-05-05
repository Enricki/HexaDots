using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    private LevelData _data;
    public void OnEnable()
    {
        _data = (LevelData)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20);
        if (GUILayout.Button("Reset Level"))
        {
            _data.ResetData();
        }
    }
}
