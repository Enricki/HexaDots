public abstract class MovementBaseState
{
    private bool _isRootState = false;
    private MovementStateMachine _context;
    private MovementStateFactory _factory;
    private MovementBaseState _currentSubState;
    private MovementBaseState _currentSuperState;

    protected bool IsRootState { set { _isRootState = value; } }
    protected MovementStateMachine Context { get { return _context; } }
    protected MovementStateFactory Factory { get { return _factory; } }

    public MovementBaseState(MovementStateMachine context, MovementStateFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubState();
         
    public void UpdateStates() 
    {
        UpdateState();
        if (_currentSubState != null)
        {
            _currentSubState.UpdateState();
        }
    }
    protected void SwitchState(MovementBaseState newState)
    {
        ExitState();

        newState.EnterState();

        if (_isRootState)
        {
            _context.CurrentState = newState;
        }
        else if (_currentSuperState != null)
        {
            _currentSuperState.SetSubState(newState);
        }
    }
    void SetSuperState(MovementBaseState newSuperState) 
    {
        _currentSubState = newSuperState;
    }
    void SetSubState(MovementBaseState newSubstate) 
    {
        _currentSubState = newSubstate;
        newSubstate.SetSuperState(this);
    }
}