using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class waypoint : MonoBehaviour
{

    public List<Transform> waypoints = new List<Transform>();
    //public GameObject[] waypoints;
    private Transform targetpoint;
    private int targetpointindex=0;
    private float distance = 0.1f;
    private int lastpointIndex;
    private float moveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        //storing last index
        lastpointIndex = waypoints.Count - 1;
        targetpoint = waypoints[targetpointindex];
    }

    // Update is called once per frame
    void Update()
    {
        float moveforward = moveSpeed * Time.deltaTime;

        //check distance for waypoints
        float distance = Vector3.Distance(transform.position, targetpoint.position);
        distancepoint(distance);
        //move racer forward
        transform.position = Vector3.MoveTowards(transform.position, targetpoint.position, moveforward);
        
    }

    void distancepoint(float Distancenow)
    {
        if (Distancenow <= distance)
        {
            targetpointindex++;
            Debug.Log(targetpointindex);
            updatepoint();
        }
    }
    void updatepoint()
    {
        if (targetpointindex > lastpointIndex)
        {
            targetpointindex = 0;
        }
        targetpoint = waypoints[targetpointindex];
    }
}
