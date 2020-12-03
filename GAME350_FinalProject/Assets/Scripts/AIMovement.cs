using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 2;
    private Transform target;
    public int wayPointIndex = 0;


    void Start()
    {   
        // At Start, the target would be the first point after the StartPoint
        target = Waypoints.waypoints[0];
    }


    // Referenced from https://www.youtube.com/watch?v=ZeeJLsEXjno&t=123s 
    void Update()
    {
        // update the target at the start 
        target = Waypoints.waypoints[wayPointIndex];

        // direction from the current position to the target position
        Vector2 direction = target.position - transform.position;
        // move the AI to the target
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            // If the AI has reached the last waypoint, then destroy itself.
            if (wayPointIndex >= Waypoints.waypoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            // Otherwise, move the AI to the next waypoint.
            wayPointIndex++;
            target = Waypoints.waypoints[wayPointIndex];
        }
    }


    /*
    public float speed;
    private Waypoints Wpoints;
    private int wayPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Get all the waypoints 
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[wayPointIndex].position, speed * Time.deltaTime);

        // If the AI has come very close to its current waypoint, then move onto the next waypoint
        if (Vector2.Distance(transform.position, Wpoints.waypoints[wayPointIndex].position) < 0.1f)
        {
            // Increment the waypoint index until the last waypoint
            if (wayPointIndex < Wpoints.waypoints.Length - 1)
            {
                wayPointIndex++;
            }
            // If the AI has reached the last waypoint, then destroy itself.
            else
            {
                Destroy(gameObject);
            }
        }
    }
    */


}
