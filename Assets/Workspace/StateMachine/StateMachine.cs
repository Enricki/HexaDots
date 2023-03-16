using UnityEngine;

public class StateMachine
{
    private State _currentState;

    public StateMachine(State state)
    {
        _currentState = state;
        _currentState.EnterState();
    }
    public void UpdateCurrentState()
    {
        _currentState.UpdateState();
    }
}