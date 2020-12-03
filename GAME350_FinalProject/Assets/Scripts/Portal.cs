using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalOut;
    public GameObject ai;

    public int portalLife = 10;


    // Start is called before the first frame update
    void Start()
    {
        // TODO: I'm not sure if this is working
        //ai = GameObject.Find("WalkingMan(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AI")
        {   
            // only teleport if portalLife is greater than 0
            if (portalLife > 0)
            {
                Teleport(collision.gameObject);
                portalLife--;
            }
            // if portalLife has reached zero, destroy portalIn and portalOut
            else
            {
                Destroy(portalOut);
                Destroy(gameObject);
            }
        }
    }


    void Teleport(GameObject enemy)
    {
        Debug.Log("TELEPORTING!");


        enemy.transform.position = new Vector2(portalOut.transform.position.x, portalOut.transform.position.y);
        Debug.Log(ai.transform.localPosition);

        int nextWaypointIndex = FindNextWaypointIndex(enemy);
        enemy.GetComponent<AIMovement>().wayPointIndex = nextWaypointIndex;


    }

    int FindNextWaypointIndex(GameObject enemy)
    {
        // these are just high arbitrary values to compare to
        float nearest = Mathf.Infinity;
        float secondNearest = Mathf.Infinity;

        int nearestIndex = 0;
        int secondNearestIndex = 0;

        for (int i = 0; i < Waypoints.waypoints.Length; i++)
        {
            //float distance = Vector2.Distance(enemy.transform.position, new Vector2(Waypoints.waypoints[i].transform.position.x, Waypoints.waypoints[i].transform.position.y));
            float distance = Vector2.Distance(enemy.transform.position, Waypoints.waypoints[i].transform.position);

            if (distance <= nearest)
            {
                secondNearest = nearest;
                secondNearestIndex = nearestIndex;

                nearest = distance;
                nearestIndex = i;
            }
            else if (distance < secondNearest)
            {
                secondNearest = distance;
                secondNearestIndex = i;
            }

            Debug.Log("Distance to index " + i + " is " + distance);
        }

        Debug.Log("The two neareast distances are: " + nearest + " and " + secondNearest);
        Debug.Log("The two neareast distances are: " + nearestIndex + " and " + secondNearestIndex);


        if (nearestIndex > secondNearestIndex)
        {
            Debug.Log("The index of the next waypoint is " + nearestIndex);
            return nearestIndex;
        } else
        {
            Debug.Log("The index of the next waypoint is " + secondNearestIndex);
            return secondNearestIndex;
        }
    }


}
