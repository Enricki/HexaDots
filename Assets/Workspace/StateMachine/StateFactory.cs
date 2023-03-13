public class StateFactory : Factory
{
    IStateContext _context;
    public StateFactory(IStateContext context) : base(context)
    {
        _context = context;
    }
}