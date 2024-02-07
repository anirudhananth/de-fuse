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
    float beeptimer = 1.0f;
    float beeptime = 1.0f;
    public bool canbeep=true;
    bool canPlaySoundEffects = true;
    
    void Start()
    {
        beeptimer = beeptime;
        timer = timerTimeInSecond;
    }

    void Update()
    {
        timer-=Time.deltaTime;
        beeptimer-=Time.deltaTime;
        if(canbeep)
        {
            TextUI.SetText(timetoString ((int)timer));
            Beep();//Play beeping sound
        }
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
        if(canPlaySoundEffects) FindFirstObjectByType<AudioManager>().Play("Alarm");
        timer = timer/2;
    }

    private void Beep()
    {
        if(beeptimer<0 && timer> 0)
        {
            if(canPlaySoundEffects) FindFirstObjectByType<AudioManager>().Play("SingleBeep");
            beeptimer = beeptime;
        }
        if(timer<=15 && timer>5)
        {
            beeptime = 0.5f;
        }
        if(timer<=5 && timer> 0)
        {
            beeptime = 0.3f;
        }
        if(timer <= 15 && timer >= 1) {
            if(!FindFirstObjectByType<AudioManager>().Sounds[16].source.isPlaying) {
                FindFirstObjectByType<AudioManager>().Play("Heartbeat");
            }
        } else {
            FindFirstObjectByType<AudioManager>().Stop("Heartbeat");
        }
    }

    public void changeCanPlaySoundEffects()
    {
        canPlaySoundEffects = !canPlaySoundEffects;
    }

    public float gettimer()
    {
        return timer;
    }
}
