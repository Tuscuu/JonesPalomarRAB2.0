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
            transitionator.SetTrigger("Lvl1Complete"); //brings the stinger down
            yield return new WaitForSeconds(transitionTime);
            transitionator.SetTrigger("SceneisTrans"); // plays the wipe in 
            yield return new WaitForSeconds(transitionTime); // pause
            SceneManager.LoadScene(index); // plays wipe out when loaded
            transitionator.SetTrigger("Lvl2Start");
        }
        else
        {
            SceneManager.LoadScene(index);
            
        }
    }
}
