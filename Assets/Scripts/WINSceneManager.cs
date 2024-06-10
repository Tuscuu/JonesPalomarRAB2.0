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
    TimeKeeper.instance.calculateTimes();
    level1Text.text = TimeKeeper.instance.level1TimeText;
    level2Text.text = TimeKeeper.instance.level2TimeText;
    totalText.text = TimeKeeper.instance.totalTimeText;
    }
}
