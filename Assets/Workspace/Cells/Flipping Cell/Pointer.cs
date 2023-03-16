using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using voidHedgeHog.Coordinates;

public class Pointer : MonoBehaviour, IMovable
{
    [SerializeField]
    private float _speed = 6f;
    private Vector3 _target;

    public Vector3 Target { get => _target; set => _target = value; }

    public void Move(Vector3 target, float movementSpeed)
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, Time.deltaTime * movementSpeed);
    }

    private void Start()
    {
        _target = transform.localPosition;
    }

    private void Update()
    {
        Move(_target, _speed);
    }
}