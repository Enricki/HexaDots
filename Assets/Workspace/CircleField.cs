using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleField : MonoBehaviour
{
    [SerializeField]
    [Range(1, 64)]
    private int _numberOfPoints = 3;

    [SerializeField]
    private float _radius = 1;

    [SerializeField]
    [Range(0, 360)]
    private int _offset = 90;

    private CircleGrid grid;

    private void Awake()
    {
        grid = new CircleGrid(_radius, _numberOfPoints, _offset);
    }

    private void OnDrawGizmos()
    {
        grid = new CircleGrid(_radius, _numberOfPoints, _offset);
        Gizmos.DrawWireSphere(transform.position, _radius);
        Gizmos.color = Color.magenta;
        for (int i = 0; i < _numberOfPoints; i++)
        {
            Gizmos.DrawSphere(grid.GetCoordsByIndex(i), 0.1f);
        }

    }
}