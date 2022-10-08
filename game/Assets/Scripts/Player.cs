using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    //private int lap=0;
    public Text PositionCounter;
    public Text Timer;
    private int seconds;
    private int minute;
    private float milli;
    private int minuteClock=0;
    private int milliClock=0;
    private int secondsClock=0;
    public Text healthText;
    private int health = 100;
    
   

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "destroyer")
        {
            health -= 10;
            healthText.text = "Health:" + health.ToString();
            if (health == 0)
            {
                SceneManager.LoadScene("lose");
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase timer
        UpdateTimer();
        
        //go to lose screen
        
    }

    public void UpdateTimer(){
        milli += (Time.deltaTime) * 1000f;
        milliClock= (int)milli;
        secondsClock= (int)seconds;
        minuteClock= (int)minute;

        if(milli >= 1000){
            seconds++;
            milli = 0;
        }else if (seconds >= 60){
             minute++;
             seconds = 0;
        }
        
        Timer.text= minuteClock.ToString("00") + ":" + secondsClock.ToString("00") + ":" + milliClock.ToString("00");  
    }


}





