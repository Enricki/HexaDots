public class Counter
{
    public int Value { get; private set; }

    public Counter(int value)
    {
        Value = value;
    }

    public void Increase()
    {
        Value++;
    }
    
    public void Reset()
    {
        Value = 0;
    }
}