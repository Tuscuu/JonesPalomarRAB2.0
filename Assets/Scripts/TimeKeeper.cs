using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{
    public static TimeKeeper instance; 

    private GameObject transitionator;
    //variables for calculation
    public float timer1;
    public float timer2;
    public float startingTime1;  // variable to hold the game's starting time
    public float startingTime2;
    public string min1;
    public string sec1;
    public string min2;
    public string sec2;
    public bool level1 = false; //for camera?
    public bool level2 = false;
    public bool lvlwin; // bool to tell scenetransitionator to start its thing
    public float level1Time;
    public float level2Time;
    public float totalTime;
    public string level1TimeText;
    public string level2TimeText;
    public string totalTimeText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Created " + instance.name);
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Debug.Log("Destroying" + instance.name);
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
        if (Input.GetKeyDown("0")) //quick switch
        {
            SceneManager.LoadScene("MainMenu");
           /* endTimers();*/ // removed endTimers as its functionality was basically sorting
                               // which we can do via passing through the build index
        }
        else if (Input.GetKeyDown("1"))
        {
            /*LevelDone(SceneManager.GetActiveScene().buildIndex);*/ // passes through the current build index before switching 
                                                                
            SceneManager.LoadScene("LevelOne");
            /*endTimers();*/
        }

        else if (Input.GetKeyDown("2"))
        {
            LevelDone(SceneManager.GetActiveScene().buildIndex); // passes through the current build index before switching
            SceneManager.LoadScene("LevelTwo");
            /*endTimers();*/
        }
        else if (Input.GetKeyDown("3"))
        {
            /*LevelDone(SceneManager.GetActiveScene().buildIndex);*/
            SceneManager.LoadScene("WIN");
            /*endTimers();*/ // End Timers on Win, Help, and Main menu did/do nothing as they dont satisfy the if else conditions
        }
        else if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("HELP");
            /*endTimers();*/
        }
    }

    public void NextLevel() 
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            SceneManager.LoadScene("LevelOne");
            Debug.Log("Moving On");
        }
        else if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            LevelDone(SceneManager.GetActiveScene().buildIndex);
            /*SceneManager.LoadScene("LevelTwo");*/
            LevelProgress();
            Debug.Log("Lvl 1 Done");
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            LevelDone(SceneManager.GetActiveScene().buildIndex);
            /*SceneManager.LoadScene("WIN");*/
            LevelProgress();
            Debug.Log("Lvl 2 Done");
        }
        else if (SceneManager.GetActiveScene().name == "HELP")
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
    public void LevelDone(int index)
    {
        if (index == 1)
        {
         level1TimeText = min1 + ":" + sec1;
        /* lvlwin = true; // starts transition*/
         level1 = false;
        }
        else if (index == 2)
        {
            level2TimeText = min2 + ":" + sec2;
            level2 = false;
        }
    }
    private void LevelProgress()
    {
        transitionator = GameObject.FindGameObjectWithTag("Transition1");
        transitionator.GetComponent<SceneTransitionator>().transition(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Level2Done()
    {
        level2TimeText = min2 + ":" + sec2;
        level2 = false;
    }
   /* public void endTimers()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            LevelDone(SceneManager.GetActiveScene().buildIndex);
        }
        else if (SceneManager.GetActiveScene().name == "LevelTwo")
        {
            LevelDone(SceneManager.GetActiveScene().buildIndex);
        }
    }*/

    public void calculateTimes()
    {
        totalTime = level1Time + level2Time;
        string min = ((int)timer2 / 60).ToString();
        string sec = (timer2 % 60).ToString("f0");
        totalTimeText = min + ":" + sec; 

    }
    public void GoToHelp()
    {
        SceneManager.LoadScene("HELP");
    }
    public void OnClickQuitButton()
    {
        print("Quit button was clicked");
        Application.Quit();
    }
}
