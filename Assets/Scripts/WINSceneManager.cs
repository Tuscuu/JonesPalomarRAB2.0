using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WINSceneManager : MonoBehaviour
{
    public static WINSceneManager instance; //singleton
    public TMP_Text level1Text;
    public TMP_Text level2Text;
    public TMP_Text totalText;
    
private void Start() {
    Debug.Log("set result times initiated");    

    UIController.instance.SetResultTimes();
}

    public void ConnectTexts(){ //connect scene TMP_Texts to the TimeKeeper
        Debug.Log("attempting to connect texts");
        UIController.instance.level1TimeText = level1Text;
        UIController.instance.level2TimeText = level2Text;
        UIController.instance.totalTimeText = totalText;
    } 
}
