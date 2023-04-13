using UnityEngine;

public class Cell : MonoBehaviour, ISelectable
{
    private Unit _unit;
    protected Collider2D _collider;

    public Unit Unit { get => _unit; set => _unit = value; }

    private void Awake()
    {
        transform.LeanScale(Vector2.zero, 0.9f).setEase(LeanTweenType.punch);
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public bool HasUnit
    {
        get
        {
            if (_unit?.GetPosition() == GetPosition()) 
            {
              
                return true;
            } 

            return false;
        }
    }

}