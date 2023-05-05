public interface IWriter<T>
{
    public T Value { get; }
    public void WriteData();
}