using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum TypeOfGridCoords
{
    Square,
    Hexagonal
}

public class GridCoordinates
{
    public Vector2Int _gridSize { get; private set; }
    public Vector2 _gridSpacingOffset { get; private set; }

    private List<Vector3> _coordsList;
    private Vector3[,] _coordsArray;
    private Vector2 _halfOffset;
    private Vector3 _gridOrigin;


    public GridCoordinates(Vector2Int gridSize, Vector2 gridSpacingOffset, TypeOfGridCoords typeOfGridCoords)
    {
        _gridSize = gridSize;
        _gridSpacingOffset = gridSpacingOffset;

        _coordsList = new List<Vector3>();
        _coordsArray = new Vector3[_gridSize.x, _gridSize.y];
        _halfOffset = 0.5f * _gridSpacingOffset;
        _gridOrigin = -new Vector3(_gridSize.x / 2.0f, _gridSize.y / 2.0f) * _gridSpacingOffset + _halfOffset;

        for (int y = 0; y < _gridSize.y; y++)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                AddCordinates(x, y, typeOfGridCoords);
            }
        }
    }

    public void AddCordinates(int xCounter, int yCounter, TypeOfGridCoords typeOfGridCoords)
    {
        Vector3 coords = Vector3.zero;

        switch (typeOfGridCoords)
        {
            case TypeOfGridCoords.Square:
                coords = new Vector3(xCounter, yCounter) * _gridSpacingOffset + (Vector2)_gridOrigin;
                _coordsList.Add(coords);
                _coordsArray[xCounter, yCounter] = coords;
                break;
            case TypeOfGridCoords.Hexagonal:
                if (yCounter % 2 != 0)
                {
                    coords = new Vector3(xCounter * _gridSpacingOffset.x + _halfOffset.x, yCounter * _gridSpacingOffset.y) + _gridOrigin;
                }
                else
                {
                    coords = new Vector3(xCounter, yCounter) * _gridSpacingOffset + (Vector2)_gridOrigin;
                }
                break;
        }
        _coordsList.Add(coords);
        _coordsArray[xCounter, yCounter] = coords;
    }

    public Vector3 GetListCoordsByIndex(int index)
    {
        return _coordsList.ElementAt(index);
    }

    public int GetCoordsCount()
    {
        return _coordsList.Count;
    }

    public Vector3 GetArrayCoordsByIndex(int x, int y)
    {
        return (_coordsArray[x, y]);
    }

    public int GetCoordsLenth(int dimension)
    {
        switch (dimension)
        {
            case 0:
                return _coordsArray.GetLength(0);
            case 1:
                return _coordsArray.GetLength(1);
            default:
                return 0;
        }
    }
}