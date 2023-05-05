using UnityEngine;
using TMPro;

public class TurnCounterView : MonoListener, IView
{
    [SerializeField]
    private TMP_Text _valueField;
    [SerializeField]
    private DataSetsKeeper _keeper;

    private void Awake()
    {
        AddListener(Events.Turn, UpdateView);
        AddListener(Events.ResetLevel, UpdateView);
        AddListener(Events.LevelEnd, UpdateView);

        UpdateView();
    }

    public void UpdateView()
    {
        _valueField.text = _keeper.CurrentSet.TurnsCount.ToString();
    }
}