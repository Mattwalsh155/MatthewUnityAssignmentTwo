using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Collider ignoreCollider;
    public float acceleration;

    private void FixedUpdate() 
    {
        GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity * acceleration, ForceMode.Force);

        transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
    }
}
