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

    }
    public override void ExitState()
    {
        _context.SendTurn();
    }
    public override void UpdateState()
    {
        _context.Controller.Move(ScreenPointPicker.ActiveSelectable.GetPosition());
        CheckSwitchStates();
    }
}