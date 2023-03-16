public class CyclicCounter : IntCounter
{
    private int _initValue;
    private int _currentValue;
    private int _cyclesCount;
    private int _zeroValue;

    private bool _decreasing;
    public int Value { get => _currentValue; }

    public CyclicCounter(int value, int cyclesCount, bool decreasing) : base(value)
    {
        _currentValue = value;
        _cyclesCount = cyclesCount;
        _decreasing = decreasing;

        _initValue = value;
        _zeroValue = value - 1;
    }

    public override void Increase()
    {
        if (_currentValue == _cyclesCount)
        {
            _currentValue = _zeroValue;
        }
        _currentValue++;
    }

    public override void Reset()
    {
        _currentValue = _initValue;
    }
}