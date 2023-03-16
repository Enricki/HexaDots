using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleField), typeof(SpriteRenderer), typeof(Collider2D))]
public class FlippingCell : Cell
{
    [SerializeField]
    private Pointer _pointerPrefab;
    [SerializeField]
    private Point _pointPrefab;

    [SerializeField]
    bool Spawn = false;

    private SpriteRenderer _renderer;
    private Collider2D _collider;

    private Pointer _pointer;
    private CyclicCounter _counter;

    [SerializeField]
    private List<Point> _points;// = new List<Point>();

    private CircleField _circleField;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _circleField = GetComponent<CircleField>();
        _counter = new CyclicCounter(1, _circleField.NumberOfPoints, true);
        _pointer = Instantiate(_pointerPrefab, transform);
        _pointer.transform.position = _circleField.Grid.GetCoordsByIndex(0);
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.GetComponent<Point>())
            {
                _points.Add(transform.GetChild(i).gameObject.GetComponent<Point>());

            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ScreenPointPicker.ActiveSelectable != this)
            {
                _counter.Increase();
                Vector3 target = _points[_counter.Value - 1].GetPosition();
                _pointer.Target = target;
                if (_points[_counter.Value - 1].PointerType == PointType.Closed)
                {
                    _collider.enabled = false;
                    _renderer.color = new Color(1f, 1f, 1f, 0.5f);
                }
                else
                {
                    _collider.enabled = true;
                    _renderer.color = new Color(1f, 1f, 1f, 1f);
                }
            }
        }
    }

    public void UpdateVisual()
    {
        //    _points = new List<Point>();
        //_pointer = Instantiate(_pointerPrefab, transform);
        //_pointer.transform.position = _circleField.Grid.GetCoordsByIndex(0);
        for (int i = 0; i < _circleField.NumberOfPoints; i++)
        {
            Point point = Instantiate(_pointPrefab, transform);
            point.transform.position = _circleField.Grid.GetCoordsByIndex(i);
            _points.Add(point);
        }
        transform.Rotate(0, 180, 0); //Костыль заставляющий двигаться Pointer по часовой;
    }



    public void ClearGrid()
    {
        while (transform.childCount != 1)
        {
           DestroyImmediate(transform.GetChild(1).gameObject);

        }
        _points.Clear();
    }

    public void GenerateGrid()
    {
        ClearGrid();
        _circleField = GetComponent<CircleField>();
        _counter = new CyclicCounter(1, _circleField.NumberOfPoints, true);
        UpdateVisual();
    }
}
//                                     UnityEditor.EditorApplication.delayCall += () =>
//{
//    UnityEditor.Undo.DestroyObjectImmediate(transform.GetChild(i).gameObject);
//};