using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]DigitIndicator digitIndicator;
    [SerializeField]int digitlength;
    [SerializeField]Timer timer;
    [SerializeField]GameObject currentDigit;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] CameraShake cameraShake;

    bool isbombdefused=false;
    bool isgameover=false;
    float gametime = 0.0f;
    bool heli=false;
    void Start()
    {
        digitIndicator = FindFirstObjectByType<DigitIndicator>();
        timer = FindFirstObjectByType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDigit = digitIndicator.CurrentDigit;
        gametime+=Time.deltaTime;
        if(gametime>=3 && !heli)
        {
            FindFirstObjectByType<AudioManager>().Play("Heli");
            heli=true;
        }
    }

    public void ButtonPressed(int value)
    {
        FindFirstObjectByType<AudioManager>().Play("ButtonPress");
        if(value == currentDigit.GetComponent<Passcode>().correctNumber)
        {
            //If the button Pressed is Correct
            currentDigit.GetComponent<Passcode>().iscorrect=true;
           FindFirstObjectByType<AudioManager>().Play(currentDigit.GetComponent<Passcode>().defusevoice);
            if(digitIndicator.digitIndex == digitlength-1)
            {
                FindFirstObjectByType<AudioManager>().Play("Correct");
                isbombdefused=true;
                isgameover=true;
                timer.canbeep=false;
            }
        }
        else
        {
            //If the button Pressed is Wrong
            timer.timerSetHalf();
            particleSystem.Play();
            cameraShake.SmallerShake();
        }
    }
}
