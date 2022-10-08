using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class destroyer : MonoBehaviour
{
    public float lifeTime = 2.0f;
    private float elapsedTime;
    // Start is called before the first frame update



    void Start()
    {
        elapsedTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
        elapsedTime += Time.deltaTime;
    }
}

