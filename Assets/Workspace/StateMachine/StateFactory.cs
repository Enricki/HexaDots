public class StateFactory : Factory
{
    IStateContext _context;
    public StateFactory(IStateContext context) : base(context)
    {
        _context = context;
    }

  //  public InitState Init() { return new InitState(_context, this); }
}