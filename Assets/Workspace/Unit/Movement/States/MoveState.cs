public class MoveState : State
{
    Unit _context;
    MovementStatesFactory _factory;
    public MoveState(Unit context, MovementStatesFactory factory) : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }

    public override void CheckSwitchStates()
    {

        if (ScreenPointPicker.ActiveSelectable.GetPosition() == _context.GetPosition())
        {
            SwitchState(_factory.Idle());
        }
    }
    public override void EnterState()
    {
        _context.Scaler.Scale(1.4f, 0.3f);
    }
    public override void ExitState()
    {
        _context.CurrentCell = (Cell)ScreenPointPicker.ActiveSelectable;
        _context.CurrentCell.Unit = _context;
        _context.SendTurn();
    }
    public override void UpdateState()
    {
        _context.Controller.Move(ScreenPointPicker.ActiveSelectable.GetPosition());
        CheckSwitchStates();
    }
}