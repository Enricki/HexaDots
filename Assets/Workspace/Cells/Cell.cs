using UnityEngine;

public class Cell : MonoBehaviour, ISelectable
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }
}