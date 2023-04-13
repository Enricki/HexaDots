using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using voidHedgeHog.Coordinates;

public class CircleGrid
{
    private Vector3 _zeroCoords;
    private float _radius;
    private float _numbersOfPoints;
    private float _offset;

    private List<Vector3> _pointsOnCircle;
    private List<float> _pointsInRad;

    public CircleGrid(Vector3 zeroCoords, float radius, float numberOfPoints, float offset)
    {
        _zeroCoords = zeroCoords;
        _radius = radius;
        _numbersOfPoints = numberOfPoints;
        _offset = offset;
        CreateGrid();
    }

    private float SectionLenth
    {
        get
        {
            return CircleCoordinates.CirclePerimeter(_radius) / _numbersOfPoints;
        }
    }

    private void CreateGrid()
    {
        _pointsInRad = new List<float>();
        float sectionLenth = SectionLenth;
        float section = 0f;
        for (int i = 0; i < _numbersOfPoints; i++)
        {
            _pointsInRad.Add(section);
            section += sectionLenth;
        }

        _pointsOnCircle = new List<Vector3>();


        for (int i = 0; i < _numbersOfPoints; i++)
        {
            Vector3 pointPosition = CircleCoordinates.CirclePointPosition(_zeroCoords, _radius, _pointsInRad[i], _offset);
            _pointsOnCircle.Add(pointPosition);
        }
    }

    public Vector3 GetCoordsByIndex(int index)
    {
        return _pointsOnCircle.ElementAt(index);
    }
}