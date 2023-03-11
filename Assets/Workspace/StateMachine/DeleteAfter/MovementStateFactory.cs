public class MovementStateFactory
{
    MovementStateMachine _context;

    public MovementStateFactory(MovementStateMachine currentContext)
    {
        _context = currentContext;
    }

    public MovementStayState Stay() 
    {
        return new MovementStayState(_context, this);
    }
    public MovementReadyState Ready() 
    {
        return new MovementReadyState(_context, this);
    }
    public MovementMoveState Move() 
    { 
        return new MovementMoveState(_context, this);
    }

}