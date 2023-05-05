using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoListener, IWriter<int>
{
    [SerializeField]
    private DataSetsKeeper _keeper;
    private Level _currentLevel;
    private AudioSource _audioSource;

    private CyclicCounter _counter;
    private int _currentLevelIndex;
    private float _delay = 0.3f;
    private EventSender _sender;
    public int Value { get => _counter.Value; private set => _currentLevelIndex = value; }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _sender = new EventSender(Events.ResetLevel);
        _counter = new CyclicCounter(0, _keeper.CurrentSet.CurrentLevelIndex, _keeper.CurrentSet.LevelsCount);


        LoadCurrentLevel();


        AddListener(Events.LevelEnd, _counter.Increase);
        AddListener(Events.LevelEnd, WriteData);
        AddListener(Events.LevelEnd, LoadCurrentLevel);
        AddListener(Events.DropU, LoadCurrentLevel);
        AddListener(Events.DropU, _audioSource.Play);
        AddListener(Events.ResetLevel, LoadCurrentLevel);
    }

    public void SendReset()
    {
        _sender.SendEvent();
    }

    private void LoadCurrentLevel()
    {
        if (_currentLevel != null)
            Destroy(_currentLevel.gameObject);
        StartCoroutine(DelayedLevelLoad(_delay));
    }

    IEnumerator DelayedLevelLoad(float sec)
    {
        yield return new WaitForSeconds(sec);
        LevelsDataSet current = _keeper.CurrentSet;
        Level instance = current.GetLevelDataByIndex(current.CurrentLevelIndex).LevelPrefab;
        _currentLevel = Instantiate(instance, transform);
        _keeper.CurrentSet.GetCurrentLevelData().Unlocked = true;
        _delay = 0.3f;
    }

    public void WriteData()
    {
        _delay = 2f;
        _currentLevelIndex = _counter.Value;
        _keeper.CurrentSet.SetCurrentLevelIndex(this);
    }
}