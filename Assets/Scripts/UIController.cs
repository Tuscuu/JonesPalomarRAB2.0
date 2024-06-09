using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    public static UIController instance; 
    
    public GameObject instructions;
    public GameObject controls;
    public TimeKeeper timeKeeper; //singleton for recording time
    public TMP_Text level1TimeText;
    public TMP_Text level2TimeText;
    public TMP_Text totalTimeText;

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

    public void NextLevel(){
        if (SceneManager.GetActiveScene().name == "MainMenu"){
            SceneManager.LoadScene("LevelOne");
        } else if (SceneManager.GetActiveScene().name == "LevelOne"){
            SceneManager.LoadScene("LevelTwo");
        } 
        
    }

    public void GoToHelp(){
        SceneManager.LoadScene("HELP");
    }

    public void Start(){
        if (SceneManager.GetActiveScene().name == "WIN"){
            string min1 = ((int)TimeKeeper.instance.level1Time / 60).ToString();     // calculates minutes
            string sec1 = (TimeKeeper.instance.level1Time % 60).ToString("f0");      // calculates seconds

        level1TimeText.text = "Elapsed Time: " + min1 + ":" + sec1;     // update level 1 stored time

            string min2 = ((int)TimeKeeper.instance.level2Time / 60).ToString();     // calculates minutes
            string sec2 = (TimeKeeper.instance.level2Time % 60).ToString("f0");      // calculates seconds

        level2TimeText.text = "Elapsed Time: " + min2 + ":" + sec2;     // update level 1 stored time

            string minTotal = ((int)TimeKeeper.instance.totalTime / 60).ToString();     // calculates minutes
            string secTotal = (TimeKeeper.instance.totalTime % 60).ToString("f0");      // calculates seconds

        totalTimeText.text = "Elapsed Time: " + minTotal + ":" + secTotal;     // update level 1 stored time
        
        }
    }

    public void InstructionsWindow(){
        if (instructions.activeSelf == false){
            instructions.SetActive(true);
        } else if (instructions.activeSelf == true){
            instructions.SetActive(false);
        }
    }

    public void ControlsWindow(){
        if (controls.activeSelf == false){
            controls.SetActive(true);
        } else if (controls.activeSelf == true){
            controls.SetActive(false);
        }
    }
}



