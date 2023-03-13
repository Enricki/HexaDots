using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoStateMachine, ISelectable
{
    [SerializeField]
    private Cell _startCell;
    [SerializeField]
    private float _movementSpeed = 6f;

    private Vector3 _startScale = new Vector3(0.5f, 0.5f);
    public bool _isMoving = false;

    private MovementStatesFactory _states;

    private void Awake()
    {
        transform.position = _startCell.GetPosition();

        _states = new MovementStatesFactory(this);
        InitStateMachine(_states.Idle());
    }

    private void Update()
    {
        UpdateCurrentState();
    }

    public void Scale(float scaler)
    {
        transform.localScale = _startScale * scaler;
    }

    public void Move(Vector3 target, float maxDistance)
    {
        float distance = Vector3.Distance(GetPosition(), target);
        if (distance < maxDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _movementSpeed);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}