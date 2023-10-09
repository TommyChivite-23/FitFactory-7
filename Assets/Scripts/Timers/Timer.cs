using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Private
    public Text timerTxt;

    //Private
    private float eT;


    void Update()
    {
        eT = Time.realtimeSinceStartup;
        DisplayTime(eT);
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60f);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60f);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
