using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine : MonoBehaviour, ISelectable
{
    MovementBaseState _currentState;
    MovementStateFactory _states;

    bool _isSelected = false;

    public MovementBaseState CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _currentState = value;
        }
    }

    public bool IsSelected
    {
        get
        {
            return _isSelected;
        }
    }

    public bool Selected { get; set; }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Awake()
    {
        _states = new MovementStateFactory(this);
        _currentState = _states.Stay();
        _currentState.EnterState();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        _currentState.UpdateState();
    }
}
