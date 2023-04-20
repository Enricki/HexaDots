using System;
using UnityEngine;

public class Cell : MonoBehaviour, ISelectable
{
    private Unit _unit;
    protected Collider2D _collider;
    protected Action _onHasUnit; 

    public Unit Unit { get => _unit; set => _unit = value; }

    private void Awake()
    {
        transform.LeanScale(Vector2.zero, 0.9f).setEase(LeanTweenType.punch); // Перенести в отдельный компонент
    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    protected bool HasUnit
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

    protected void OnHasUnit()
    {
        if (HasUnit)
        {
     //       _sender.SendEvent();
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}