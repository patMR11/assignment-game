using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    public float speed= 200.0f;
    public float lifeTime= 3.0f;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        newPosition= transform.position + transform.forward * speed * Time.deltaTime;
    }
}
