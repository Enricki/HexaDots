using UnityEngine;

public abstract class MonoStateMachine : MonoBehaviour, IStateContext
{
    private State _currentState;
    public State CurrentState { get => _currentState; set => _currentState = value; }

    public State GetCurrentState()
    {
        return _currentState;
    }

    protected void InitStateMachine(State initState)
    {
        _currentState = initState;
        _currentState.EnterState();
    }

    protected void UpdateCurrentState()
    {
        _currentState.UpdateState();
    }
}