using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class Unit : MonoBehaviour, ISelectable, IStateContext
{
    [SerializeField]
    private Cell _startCell;
    [SerializeField]
    private Vector2 _startScale = new Vector2(0.5f, 0.5f);

    private Cell _currentCell;

    private MovementController _controller;
    private Scaler _scaler;
    private AudioSource _audioSource;

    private MovementStatesFactory _states;
    private State _currentState;
    private EventSender _sender;

    private Vector3 _target;


    public MovementController Controller { get => _controller; }
    public Scaler Scaler { get => _scaler; }
    public Cell StartCell { get => _startCell; }

    public State CurrentState { set => _currentState = value; }

    public Cell CurrentCell { get => _currentCell; set => _currentCell = value; }
    public Vector3 Target { get => _target; set => _target = value; }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _controller = GetComponent<MovementController>();
        _scaler = GetComponent<Scaler>();
        _states = new MovementStatesFactory(this);
        _currentState = _states.Idle();
        _currentState.EnterState();
        _sender = new EventSender(Events.Turn);

        _currentCell = _startCell;
    }


    private void Update()
    {
        _currentState.UpdateState();
    }

    public void SendTurn()
    {
        _audioSource.Play();
        _sender.SendEvent();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void OnDestroy()
    {
        _currentState = _states.Idle();
    }
}