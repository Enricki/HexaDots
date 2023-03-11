using UnityEngine;

public class ScreenPointPicker : MonoBehaviour
{
    private Camera _camera;
    private RaycastHit2D _hit;
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
            _hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (_hit.collider != null)
            {
                if (_activeSelectable == null)
                {
                    _activeSelectable = _hit.collider.GetComponent<ISelectable>();
                    _previousSelectable = _activeSelectable;
                }
                else
                {
                    _previousSelectable = _activeSelectable;
                    _activeSelectable = _hit.collider.GetComponent<ISelectable>();
                }
            }
        }
    }
}