public class MoveState : State
{
    MovementController _context;
    MovementStatesFactory _factory;
    public MoveState(MovementController context, MovementStatesFactory factory) : base(context, factory)
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

    }
    public override void UpdateState()
    {
        _context.Move(ScreenPointPicker.ActiveSelectable.GetPosition(), 1);
        CheckSwitchStates();
    }
}
//https://www.youtube.com/watch?v=kV06GiJgFhc - Посмотреть как осуществляется Свитч стэйтов