using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] int timerTimeInSecond = 120; //Default set the timer to 120 seconds
    [SerializeField] TMP_Text TextUI;
    float timer = 120f;
    
    void Start()
    {
        
        timer = timerTimeInSecond;
    }

    void Update()
    {
        timer-=Time.deltaTime;
        TextUI.SetText(timetoString ((int)timer));


//Debug Part
/*
        if(Input.anyKeyDown)
        {
            timerSetHalf();
        }
*/
    }

    private String timetoString (int timeInSecond)
    {
        if(timeInSecond<0)
        {
            return "00:00";
        }
        int minute = timeInSecond/60;
        int second = timeInSecond%60;
        return minute.ToString("00")+ ":" + second.ToString("00");
    }

    public void timerSetHalf()
    {
        timer = timer/2;
    }
}
