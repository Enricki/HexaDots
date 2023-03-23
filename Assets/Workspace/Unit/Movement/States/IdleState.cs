public class IdleState : State
{
    Unit _context;
    MovementStatesFactory _factory;
    public IdleState(Unit context, MovementStatesFactory factory) : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }

    public override void CheckSwitchStates()
    {
        if (ScreenPointPicker.ActiveSelectable != null)
        {
            if (_context == ScreenPointPicker.ActiveSelectable)
            {
                SwitchState(_factory.Ready());
            }
        }
    }


    public override void EnterState()
    {
        _context.Scale(1);
    }

    public override void ExitState() { }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}