using UnityEngine;

public class Cell : MonoBehaviour, ISelectable
{
    public Vector3 GetPosition()
    {
        if (transform != null)
            return transform.position;
        return Vector3.zero;
    }

    public void Select()
    {
        OnSelect();
    }

    public void Deselect()
    {
        Debug.Log("Deselected: " + gameObject.name + " : " + transform.position);
    }

    protected virtual void OnSelect()
    {
        Debug.Log("Selected: " + gameObject.name + " : " + transform.position);
    }
}