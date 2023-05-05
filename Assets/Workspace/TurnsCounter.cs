using UnityEngine;
public class TurnsCounter : MonoListener, IWriter<int>
{
    [SerializeField]
    private DataSetsKeeper _keeper;

    private LinearCounter _counter;
    private int _turnsCount = 0;

    public int Value { get => _counter.Value; private set => _turnsCount = value; }
    private void Awake()
    {
        _counter = new LinearCounter(_turnsCount);
        WriteData();

        AddListener(Events.Turn, _counter.Increase);
        AddListener(Events.Turn, WriteData);

        AddListener(Events.ResetLevel, _counter.Reset);
        AddListener(Events.ResetLevel, WriteData);

        AddListener(Events.LevelEnd, _counter.Reset);
        AddListener(Events.LevelEnd, WriteData);
    }

    public void WriteData()
    {
        _turnsCount = _counter.Value;
        _keeper.CurrentSet.SetTurnsCount(this);
    }
}