using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;



    void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance!= this){
            Destroy(gameObject);
        }
    }
}
/*
    void Update(){                      //testing between scenes; quick switch 
        // FUNCTIONALITY MOVED TO TIMEKEEPER
        if (Input.GetKeyDown("0")){
            SceneManager.LoadScene("MainMenu");
            endTimers();
        }
        else if (Input.GetKeyDown("1")){
            SceneManager.LoadScene("LevelOne");
            endTimers();
        }

        else if (Input.GetKeyDown("2")){
            SceneManager.LoadScene("LevelTwo");
            endTimers();
        }
        else if (Input.GetKeyDown("3")){
            SceneManager.LoadScene("WIN");
            endTimers();
        }
        else if (Input.GetKeyDown("4")){
            SceneManager.LoadScene("HELP");
            endTimers();
        }

    public void endTimers(){
        if (SceneManager.GetActiveScene().name == "LevelOne"){
            TimeKeeper.instance.Level1Done();
        } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
            TimeKeeper.instance.Level2Done();
        }
    }*/


