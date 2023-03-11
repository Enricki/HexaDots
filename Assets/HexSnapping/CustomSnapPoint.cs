using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSnapPoint : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.5f);

        Gizmos.DrawSphere(transform.position, 0.1f * Parametrs.CoordsScaler);
    }
}
