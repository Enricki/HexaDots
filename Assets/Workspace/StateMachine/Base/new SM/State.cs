public abstract class State
{
    private IStateContext _context;
    private StateFactory _factory;

    protected IStateContext Context { get { return _context; } }
    protected StateFactory Factory { get { return _factory; } }

    public State(IStateContext context, StateFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();

    protected void SwitchState(State newState)
    {
        ExitState();
        newState.EnterState();
        _context.CurrentState = newState;
    }
}