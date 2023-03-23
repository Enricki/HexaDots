using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Parametrs
{
    public static float CoordsScaler = 1;


    public static bool isSelected
    {
        get
        {
            if(ScreenPointPicker.ActiveSelectable != null)
            {
                return true;
            }
            return false;
        }
    }

}