using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Field))]
public class FieldEditor : Editor
{
    private Field _field;
    public void OnEnable()
    {
        _field = (Field)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(20);
        if (GUILayout.Button("InitCells"))
        {
            _field.InitCells();
        }
    }
}

