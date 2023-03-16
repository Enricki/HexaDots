using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IStateContext, ISelectable, IMovable
{
    [SerializeField]
    private Cell _startCell;
    [SerializeField]
    private float _movementSpeed = 6f;

    private Vector3 _startScale = new Vector3(0.5f, 0.5f);
    public bool _isMoving = false;

    private MovementStatesFactory _states;

    private State _currentState;
    public State CurrentState { set => _currentState = value; }

    private void Awake()
    {
        transform.position = _startCell.GetPosition();

        _states = new MovementStatesFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
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