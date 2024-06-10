using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionator : MonoBehaviour
{
    public Animator transitionator; 
    public UIController controller;
    public float transitionTime = 1f; //determines how long splash screen is up
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.lvlwin)
        {
            transition();
        }
    }
    void transition()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne") // This transition is specific to level 1
        {
            StartCoroutine("Trans");
        }
       
        controller.NextLevel();
    }
    IEnumerator Trans()
    {
        transitionator.SetTrigger("Lvl1Complete"); //brings the stinger down
        yield return new WaitForSeconds(transitionTime); // pause
        transitionator.SetTrigger("SceneisTrans"); // plays the wipe in and out to level 2
    }
}
