public interface IStateContext : IContext
{
    public State CurrentState { get; set; }
}
