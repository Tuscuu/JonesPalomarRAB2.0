using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransitionator : MonoBehaviour
{
    public Animator transitionator; 
    /*public UIController controller;*/ // Deprecated
    public float transitionTime = 1f; //determines how long splash screen is up
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (TimeKeeper.instance.lvlwin)
        {
            transition();
            TimeKeeper.instance.lvlwin = false;
        }*/
       if (SceneManager.GetActiveScene().name == "LevelTwo") 
        {
            transitionator.SetBool("InLevels", true);
            Debug.Log("In Levels should be true");
        }
    }
    public void transition(int index)
    {
        
            StartCoroutine(Trans(index));
       /* TimeKeeper.instance.NextLevel();*/
    }
    private IEnumerator Trans(int index)
    {
        if (index == 2)
        {
            
            Debug.Log("Enter Transition");
            transitionator.SetTrigger("Lvl1Complete"); //brings the stinger down
            Debug.Log("first transition");
            yield return new WaitForSeconds(transitionTime);
         /*   transitionator.SetBool("InLevels", true);
            Debug.Log("In Levels should be true");*/
            transitionator.SetTrigger("SceneisTrans"); // plays the wipe in 
            yield return new WaitForSeconds(transitionTime); // pause
            SceneManager.LoadScene(index); // plays wipe out when loaded
           /* yield return new WaitForSeconds(1f);
            transitionator.SetBool("InLevels", true);
            Debug.Log("In Levels should be true");*/
        }
        else
        {
            
            SceneManager.LoadScene(index);
         /*   transitionator.SetBool("InLevels", true);
            Debug.Log("In Levels should be true");*/
        }
    }
}
