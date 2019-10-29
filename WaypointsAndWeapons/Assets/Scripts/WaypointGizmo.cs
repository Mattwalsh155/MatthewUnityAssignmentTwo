using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Gizmo - an object or shape so you can visually see where things are
public class WaypointGizmo : MonoBehaviour
{
    public float radius;

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.magenta; // new Color(255,105,180,255);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
