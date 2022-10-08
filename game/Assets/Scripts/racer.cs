using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class racer : MonoBehaviour
{
    
    
   

   
    public GameObject[] waypointList;
    private NavMeshAgent nav;
    public int waypointnumber;
    Vector3 next;
    // Start is called before the first frame update
    void Start()
    {
        
        nav=GetComponent<NavMeshAgent>();
        FindNextPoint();
    }
    // Update is called once per frame
    void Update()
    {
        
       if (Vector3.Distance(transform.position, next ) <= 10.0f)
        {
            IteratePoint();
            FindNextPoint();
        }
    }
    protected void FindNextPoint(){
        //Debug.Log(waypointnumber);
        next= waypointList[waypointnumber].transform.position ;
        nav.SetDestination(next);
    }
    
    protected void IteratePoint(){
        waypointnumber+=1;
        Debug.Log(waypointnumber);
        if (waypointnumber==waypointList.Length){
            waypointnumber=0;
        }
    }
    
}
