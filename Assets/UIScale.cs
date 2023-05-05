using UnityEngine;
using UnityEngine.UI;

public class UIScale : MonoListener, IWriter<int>
{
    [SerializeField]
    private DataSetsKeeper _dataKeeper;
    private Image _image;

    private int _current = 0;
    private float _subStep = 0;
    private int _achievedScore;
    private int _turns = 0;

    public int Value { get => _achievedScore; private set => _achievedScore = value; }

    private void Awake()
    {
        AddListener(Events.Turn, DropScale);
        AddListener(Events.ResetLevel, ResetScale);

        AddListener(Events.LevelEnd, WriteData);
        AddListener(Events.LevelEnd, ResetScale);
    }

    private void Start()
    {
        _image = GetComponent<Image>();
        ResetScale();
    }

    private void DropScale()
    {
        LevelsDataSet dataset = _dataKeeper.CurrentSet;

        float fillAmount = _image.fillAmount;
        int currentLevelValue = dataset.GetCurrentLevelData().GetCurrentLevelValue(dataset.TurnsCount);
        _turns = dataset.TurnsCount;
        int endValue = dataset.GetCurrentLevelData().GetScoreLevelValue(dataset.GetCurrentLevelData().ScoreLevelsCount - 1) + 1;
        float exet = (float)endValue / (dataset.GetCurrentLevelData().ScoreLevelsCount + 1);

        if (_current != currentLevelValue)
        {
            _subStep = 0.1f / (exet / (currentLevelValue - _current) * 0.1f);
            _current = currentLevelValue;
        }

        float step = 0.1f / (endValue * 0.1f);

        fillAmount -= step / _subStep;
        _image.fillAmount = fillAmount;
    }

    private void ResetScale()
    {
        _current = 0;
        _subStep = 0;
        _turns = 0;
        _image.fillAmount = 1f;
    }

    public void WriteData()
    {
        LevelsDataSet dataset = _dataKeeper.CurrentSet;
        _achievedScore = dataset.GetCurrentLevelData().CheckCurrentLevel(_turns);
        if (_achievedScore > dataset.GetCurrentLevelData().AchievedScore)
        {
            _dataKeeper.CurrentSet.GetCurrentLevelData().SetAchievedScore(this);
        }
    }
}