using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMissile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float turningSpeed;
    public Collider ignoreCollider;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calculate the direction from the current position to the target
        Vector3 targetDirection = target.position - transform.position;

        //Calculate the rotation required to point at the target
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

        //Move forward toward target
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other != ignoreCollider)
        {
            target = other.transform;
        }
    }
}
