public class Factory
{
    private IContext _context;

    public Factory(IContext currentContext)
    {
        _context = currentContext;
    }
}