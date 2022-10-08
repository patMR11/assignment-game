using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Finish : MonoBehaviour
{

    public Text scoreText;
    private int lap=0;

    // Start is called before the first frame update

    

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "wheel") {
			lap+=1;
            scoreText.text="Lap:"+lap.ToString()+"/3";
            //Debug.Log(final);  
		}
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lap==3){
            //Debug.Log("hello");
            SceneManager.LoadScene("ending");
        }
    }

}

