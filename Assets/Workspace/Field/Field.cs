using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField]
    private List<Cell> cells = new List<Cell>();

    private void Awake()
    {
        InitCells();
    }

    public void InitCells()
    {
        if (cells != null)
        {
            cells.Clear();
        }
        foreach (var cell in GetComponentsInChildren<Cell>())
        {
            cells.Add(cell);
        }
    }
}