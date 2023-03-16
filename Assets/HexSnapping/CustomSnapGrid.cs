using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSnapGrid : MonoBehaviour//, IEditorInstancer
{
    [SerializeField]
    private CustomSnap _snapPrefab;
    [SerializeField]
    private Vector2Int _size;
    [SerializeField]
    Vector2 _offset = new Vector2(0.9f, 0.77f);
    [SerializeField]
    TypeOfGridCoords typeOfGrid;
    [Space(20)]
    private Transform _initTransform;
    private List<CustomSnap> _snap = new List<CustomSnap>();

    [SerializeField]
    private float _scaler = 1;

    public void GenerateGrid()
    {
        GridCoordinates hexCoordinates = new GridCoordinates(_size, _offset, typeOfGrid);
        Parametrs.CoordsScaler = _scaler;
        ClearGrid();

        for (int y = 0; y < _size.y; y++)
        {
            for (int x = 0; x < _size.x; x++)
            {
                CustomSnap snap = Instantiate(_snapPrefab, _initTransform);
                Vector3 position = hexCoordinates.GetArrayCoordsByIndex(x, y);
                snap.transform.localPosition = position * Parametrs.CoordsScaler;
                _snap.Add(snap);
            }
        }
    }

    public void ClearGrid()
    {
        while(transform.childCount !=0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        _snap.Clear();
    }

    private void OnValidate()
    {
        _initTransform = transform;
        if (_scaler <= 0) _scaler = 1;
    }

    public void Generate()
    {
        GenerateGrid();
    }

    public void Clear()
    {
        ClearGrid();
    }
}
