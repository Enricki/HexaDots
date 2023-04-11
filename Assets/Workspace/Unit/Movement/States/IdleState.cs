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
        if ((Cell)ScreenPointPicker.ActiveSelectable != null)
        {
            if (_context.GetPosition() != ScreenPointPicker.ActiveSelectable.GetPosition())
            {
                SwitchState(_factory.Move());
            }
        }
    }


    public override void EnterState()
    {
        _context.Scaler.Scale(1f, 0.3f);
    }

    public override void ExitState() { }
    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}