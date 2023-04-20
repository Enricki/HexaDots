using UnityEngine;
using TMPro;
public class LevelCounterView : MonoListener, IView
{
    [SerializeField]
    private TMP_Text _valueField;
    [SerializeField]
    private DataSetsKeeper _keeper;

    private void Awake()
    {
        AddListener(Events.LevelEnd, UpdateView);
        UpdateView();
    }

    public void UpdateView()
    {
        LevelsDataSet dataSet = _keeper.CurrentSet;
        _valueField.text = dataSet.CurrentLevelIndex.ToString();
    }
}