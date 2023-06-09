using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(CircleField), typeof(SpriteRenderer))]
public class FlippingCell : Cell
{
    [SerializeField]
    private Pointer _pointerPrefab;
    [SerializeField]
    private Point _pointPrefab;

    [SerializeField]
    private PointVisual[] _pointsOfTypes;

    private Pointer _pointer;
    private CyclicCounter _counter;

    private CircleField _circleField;
    private SpriteRenderer _renderer;
    private List<Point> _points;
    private EventListener _eventListener;
    private EventSender _sender;
    private Color defaultColor;


    public Pointer Pointer { get => _pointer; }
    public CircleField CircleField { get => _circleField; }




    private void Awake()
    {

        _eventListener = new EventListener(Events.Turn);
        _sender = new EventSender(Events.DropU);
    //   
    }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _circleField = GetComponent<CircleField>();
        _counter = new CyclicCounter(0,0, _circleField.NumberOfPoints);
        AddPoints();
        AddPointer();
        defaultColor = _renderer.color;
     //   transform.LeanScale(Vector2.zero, 0.9f).setEase(LeanTweenType.punch); // ��������� � ��������� ���������
    }

    private void AddPointer()
    {
        _pointer = Instantiate(_pointerPrefab, transform);
        _pointer.transform.position = _points.ElementAt(_counter.Value).GetPosition();
    }


    private void AddPoints()
    {
        _points = new List<Point>();
        for (int i = 0; i < _circleField.NumberOfPoints; i++)
        {
            Point instance = Instantiate(_pointPrefab, transform);
            instance.transform.position = _circleField.Grid.GetCoordsByIndex(i);
            instance.Visual = _pointsOfTypes[i];
            _points.Add(instance);
        }

    }

    /// <summary>
    /// ���������� �� ����������
    /// </summary>
    private void MovePointer()
    {

        _counter.Increase();
        Point currentPoint = _points.ElementAt(_counter.Value);
        Point nextPoint = currentPoint;
        if (_counter.Value + 1 < _points.Count)
        {
            nextPoint = _points.ElementAt(_counter.Value + 1);
        }
        else
        {
            nextPoint = _points.ElementAt(0);
        }

        Vector3 target = currentPoint.GetPosition(); //_circleField.Grid.GetCoordsByIndex(_counter.Value - 1);
        _pointer.Target = target;

        if (currentPoint.PointType == PointType.Closed)
        {
            _renderer.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.5f);
            OnHasUnit();
        }
        else
        {
            _renderer.color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 1f);
        }
    }

    public void ClearGrid()
    {
        while (transform.childCount != 1)
        {
            DestroyImmediate(transform.GetChild(1).gameObject);

        }
        if (_points != null)
        {
            _points.Clear();
        }
    }

    public void GenerateGrid()
    {
        ClearGrid();
        _circleField = GetComponent<CircleField>();
        _counter = new CyclicCounter(0,0, _circleField.NumberOfPoints);
        AddPoints();
    }


    private void OnEnable()
    {
        _eventListener.Subscribe(MovePointer);
    }

    private void OnDisable()
    {
        _eventListener.UnSubscribe(MovePointer);
    }

    private void OnValidate()
    {
        _circleField = GetComponent<CircleField>();
        if (_pointsOfTypes.Length != _circleField.NumberOfPoints)
        {
            _pointsOfTypes = new PointVisual[_circleField.NumberOfPoints];
        }
    }

    private void OnHasUnit()
    {
        if (HasUnit)
        {
            _sender.SendEvent();
        }
    }
}