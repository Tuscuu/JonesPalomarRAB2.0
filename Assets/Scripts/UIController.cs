using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public static UIController instance; 
    

    public TimeKeeper timeKeeper; //singleton for recording time
    public TMP_Text level1TimeText;
    public TMP_Text level2TimeText;
    public TMP_Text totalTimeText;
    public bool lvlwin; // used to send signal to SceneTransitionator
    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance!= this){
            Destroy(gameObject);
        }
    }


	public void OnClickQuitButton()
    {
        print("Quit button was clicked");
        Application.Quit();
    }
    public void WinLevel() // A little bit roundabout but this is what is called in PlayerController
    {                       // broadcast to other scripts the level is done, because I didn't want to
        lvlwin = true;                      // deal with passing in another public object

    }
    public void NextLevel(){
        if (SceneManager.GetActiveScene().name == "MainMenu"){
            SceneManager.LoadScene("LevelOne");
        } else if (SceneManager.GetActiveScene().name == "LevelOne"){
            SceneManager.LoadScene("LevelTwo");
            TimeKeeper.instance.Level1Done();
        } else if (SceneManager.GetActiveScene().name == "LevelTwo"){
            SceneManager.LoadScene("WIN");
            TimeKeeper.instance.Level2Done();
        } 
        else if (SceneManager.GetActiveScene().name == "HELP"){
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    public void GoToHelp(){
        SceneManager.LoadScene("HELP");
    }

}



