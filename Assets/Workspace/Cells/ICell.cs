using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICell : ISelectable
{
    public Unit Unit { get; set; }
}