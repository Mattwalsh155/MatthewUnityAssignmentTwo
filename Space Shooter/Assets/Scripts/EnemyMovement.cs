using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject enemy;
    public Transform player;
    public int moveSpeed;
    public int maxDist;
    public int minDist; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Transform>();

        //transform.LookAt(player);

        // if (Vector3.Distance(transform.position, player.position) >= minDist)
        // {
        //     transform.position += transform.forward * moveSpeed * Time.deltaTime;
        // }

        // Move our position a step closer to the target.
        float step =  moveSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);

        // Check if the position equals minDist
        if (Vector2.Distance(transform.position, player.position) >= minDist)
        {
          
        }
    }
}
