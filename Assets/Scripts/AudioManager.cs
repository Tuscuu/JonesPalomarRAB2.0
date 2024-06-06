using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;

    void Awake() {
        if (instance != null) {     //if there is already another music object, destroy it. 
            Destroy(gameObject);
        }

        else {
            instance = this;        //otherwise, the instance is this music object 
            DontDestroyOnLoad(gameObject);
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
