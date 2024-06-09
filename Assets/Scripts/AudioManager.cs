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

    void Update(){                      //testing between scenes; quick switch 
        if (Input.GetKeyDown("1")){
            SceneManager.LoadScene("LevelOne");
        }

        else if (Input.GetKeyDown("2")){
            SceneManager.LoadScene("LevelTwo");
        }
    }

}
