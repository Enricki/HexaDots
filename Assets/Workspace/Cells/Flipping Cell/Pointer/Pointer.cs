using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using voidHedgeHog.Coordinates;

[RequireComponent(typeof(MovementController))]
public class Pointer : MonoBehaviour
{
    private MovementController _controller;
    private Vector3 _target;

    public Vector3 Target { set => _target = value; }
    private void Start()
    {
        _controller = GetComponent<MovementController>();
        _target = transform.position;
    }

    private void Update()
    {
        _controller.Move(_target);
    }
}