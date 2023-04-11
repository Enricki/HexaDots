using UnityEngine;

public class ScreenPointPicker : MonoBehaviour
{
    private Camera _camera;
    private static ISelectable _activeSelectable;
    private static ISelectable _previousSelectable;

    public static ISelectable ActiveSelectable
    {
        get
        {
            if (_activeSelectable != null)
            {
                return _activeSelectable;
            }
            return null;
        }
    }

    private void Start()
    {
        if (_activeSelectable != null)
        {
            _activeSelectable = null;
        }
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                //_activeSelectable = hit.collider.GetComponent<ISelectable>();


                if (_activeSelectable == null)
                {
                    _activeSelectable = hit.collider.GetComponent<ISelectable>();
                    //     _previousSelectable = _activeSelectable;
                }
                else
                {
                    //    _previousSelectable = _activeSelectable;
                    _activeSelectable = hit.collider.GetComponent<ISelectable>();
                }
            }
        }
    }
}