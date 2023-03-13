public class CyclicCounter : IntCounter
{
    private int _initValue;
    private int _currentValue;
    private int _cyclesCount;
    private int  _zeroValue;

    public int Value { get => _currentValue; }

    public CyclicCounter(int value, int cyclesCount) : base(value)
    {
        _currentValue = value;
        _cyclesCount = cyclesCount;

        _initValue = value;
        _zeroValue = value - 1;
    }

    public override void Increase()
    {
        if(_currentValue == _cyclesCount)
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