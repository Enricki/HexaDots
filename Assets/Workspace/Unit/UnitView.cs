using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitView
{
    private Transform _transform;

    public Vector3 nextPos;

    public UnitView(Transform transform)
    {
        _transform = transform;

    }

    public void UpdateView()
    {
        _transform.localPosition = Vector3.MoveTowards(_transform.localPosition, nextPos, 6);
    }
}
