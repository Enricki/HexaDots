public class ReadyState : State
{
    MovementController _context;
    MovementStatesFactory _factory;
    public ReadyState(MovementController context, MovementStatesFactory factory) : base(context, factory)
    {
        _context = context;
        _factory = factory;
    }

    public override void CheckSwitchStates()
    { 
        if (_context != ScreenPointPicker.ActiveSelectable)
        {
            SwitchState(_factory.Move());
        }


    }
    public override void EnterState() 
    {
        _context.Scale(1.4f);
    }

    public override void ExitState() { }
    public override void UpdateState() 
    {
        CheckSwitchStates();
    }
}
//https://www.youtube.com/watch?v=kV06GiJgFhc - Посмотреть как осуществляется Свитч стэйтов