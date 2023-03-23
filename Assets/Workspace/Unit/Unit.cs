using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class Unit : MonoBehaviour, ISelectable, IStateContext
{
    [SerializeField]
    private Vector3 _startScale = new Vector3(0.5f, 0.5f);

    private MovementController _controller;
    private MovementStatesFactory _states;
    private State _currentState;
    private EventSender _sender;
    private Vector3 _target;

    public State CurrentState { set => _currentState = value; }
    public MovementController Controller { get => _controller; }
    public Vector3 Target { get => _target; set => _target = value; }

    private void Awake()
    {
        _controller = GetComponent<MovementController>();
        _states = new MovementStatesFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
        _sender = new EventSender(Events.Turn);
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void SendTurn()
    {
        _sender.SendEvent();
    }

    public void Scale(float scaler) //Переделать позже под анимацию, убрать из контроллера
    {
        transform.localScale = _startScale * scaler;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
