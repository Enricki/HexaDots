using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace voidHedgeHog.Coordinates
{
    public static class Extentions
    {
        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }
    }
}

