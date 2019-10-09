using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gizmo : MonoBehaviour 
    //lightsaber pivot position = 0, 0.205 (.005 above the handle), 0
{
    [Header("Hold 'V' to lock on existing objects")]
    public float gizmoSize = .75f;
    public Color gizmoColor = Color.yellow;

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }


}
