using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<Vector3> waypoints;
    private Rigidbody playerRB;
    private int currentWaypoint;

    private float distance;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new List<Vector3>();
        playerRB = GetComponent<Rigidbody>();
        currentWaypoint = 0;
        maxSpeed = 3;

        for (int i = 0; i < 5; i++)
        {
            waypoints.Add(GameObject.Find("Waypoint" + i).GetComponent<Transform>().position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = transform.position.x - waypoints[currentWaypoint].x;

        transform.LookAt(waypoints[currentWaypoint]);

        playerRB.velocity = (waypoints[currentWaypoint] - transform.position).normalized * maxSpeed;
        // playerRB.velocity = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint], 2);

        if (playerRB.velocity.x > maxSpeed)
        {
            playerRB.velocity = new Vector2(maxSpeed,playerRB.velocity.y);
        }

        if (playerRB.velocity.y > maxSpeed)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, maxSpeed);
        }

        if (distance <= 0.1f && distance >= -0.1f)
        {
            currentWaypoint++;
            playerRB.velocity = Vector2.zero;
            Debug.Log(playerRB.velocity);

            if (currentWaypoint > waypoints.Count - 1)
            {
                currentWaypoint = 0;
            }
        }
    }
}
