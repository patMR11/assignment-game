using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onDrawGizmos(){
        Gizmos.DrawIcon(new Vector3(transform.position.x, 0.5f, transform.position.z), "Assets/images/titlecard.png");
    }
}
