public class ReadyState : State
{
    Unit _context;
    MovementStatesFactory _factory;
    public ReadyState(Unit context, MovementStatesFactory factory) : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }

    public override void CheckSwitchStates()
    {
        SwitchState(_factory.Move());
    }
    public override void EnterState()
    {

    }

    public override void ExitState() { }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}