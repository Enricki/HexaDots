using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoListener
{
    [SerializeField]
    private DataSetsKeeper _keeper;
    private Level _currentLevel;

    //    private EventSender _sendReset;

    private void Awake()
    {

        //        _sendReset = new EventSender(Events.ResetLevel);
        LoadCurrentLevel();
        AddListener(Events.LevelEnd, LoadCurrentLevel);
        AddListener(Events.DropU, LoadCurrentLevel);
        AddListener(Events.ResetLevel, LoadCurrentLevel);
    }

    //public void SendResetLevel()
    //{
    //    _sendReset.SendEvent();
    //}

    //private void ResetLevelOnDrop()
    //{
    //    StartCoroutine(WaitForSeconds(0.3f));
    //}

    private void LoadCurrentLevel()
    {
        if (_currentLevel != null)
            Destroy(_currentLevel.gameObject);
        StartCoroutine(DelayedLevelLoad(0.3f));
    }

    IEnumerator DelayedLevelLoad(float sec)
    {
        yield return new WaitForSeconds(sec);
        LevelsDataSet current = _keeper.CurrentSet;
        Level instance = current.GetLevelDataByIndex(current.CurrentLevelIndex).LevelPrefab;
        _currentLevel = Instantiate(instance, transform);
    }
}