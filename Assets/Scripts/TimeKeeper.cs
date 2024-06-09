using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{
    public static TimeKeeper instance; 

    //variables for calculation
    public float timer1;
    public float timer2;
    public float startingTime1;  // variable to hold the game's starting time
    public float startingTime2;
    public string min1;
    public string sec1;
    public string min2;
    public string sec2;
    public bool level1 = false;
    public bool level2 = false;

    public float level1Time;
    public float level2Time;
    public float totalTime;

    void Awake()    //singleton mortality
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance!= this){
            Destroy(gameObject);
        }
    }

    private void Update(){
        if (level1){
            timer1 = Time.time - startingTime1;     // local variable to updated time
            min1 = ((int)timer1 / 60).ToString();     // calculates minutes
            sec1 = (timer1 % 60).ToString("f0");      // calculates seconds
        }
        else if (level2){
            timer2 = Time.time - startingTime2;
            min2 = ((int)timer2 / 60).ToString();
            sec2 = (timer2 % 60).ToString("f0");

        }
    }

    public void Level1Done(){
        level1Time = timer1;
        level1 = false;
    }

    public void Level2Done(){
        level2Time = timer2;
        level2 = false;
    }

}
