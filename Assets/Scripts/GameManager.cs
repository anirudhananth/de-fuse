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
    [SerializeField] ParticleSystem particleSystem1;
    [SerializeField] ParticleSystem particleSystem2;
    [SerializeField] CameraShake cameraShake;

    bool isbombdefused=false;
    bool isgameover=false;
    float gametime = 0.0f;
    bool heli=false;
    bool canShakeCamera = true;
    bool canShowElectricity = true;
    bool canPlaySoundEffects = true;
    void Start()
    {
        digitIndicator = FindFirstObjectByType<DigitIndicator>();
        timer = FindFirstObjectByType<Timer>();
        particleSystem2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        currentDigit = FindFirstObjectByType<DigitIndicator>().CurrentDigit;
        gametime+=Time.deltaTime;
        if(gametime>=3 && !heli)
        {
            FindFirstObjectByType<AudioManager>().Play("Heli");
            heli=true;
        }
    }

    public void ButtonPressed(int value)
    {
        if(canPlaySoundEffects) FindFirstObjectByType<AudioManager>().Play("ButtonPress");
        if(value == currentDigit.GetComponent<Passcode>().correctNumber)
        {
            //If the button Pressed is Correct
            currentDigit.GetComponent<Passcode>().iscorrect=true;
            if(canPlaySoundEffects) FindFirstObjectByType<AudioManager>().Play(currentDigit.GetComponent<Passcode>().defusevoice);
            if(FindFirstObjectByType<DigitIndicator>().digitIndex == digitlength-1)
            {
                if(canPlaySoundEffects) FindFirstObjectByType<AudioManager>().Play("Correct");
                isbombdefused=true;
                isgameover=true;
                timer.canbeep=false;
            }
        }
        else
        {
            //If the button Pressed is Wrong
            timer.timerSetHalf();
            if(canShowElectricity) particleSystem1.Play();
            if(canShakeCamera) cameraShake.SmallerShake();
        }
    }

    public void changeCameraShake()
    {
        canShakeCamera = !canShakeCamera;
    }

    public void changeShowElectricity()
    {
        canShowElectricity = !canShowElectricity;
        if(canShowElectricity == true) {
            particleSystem2.Play();
        } else {
            particleSystem2.Stop();
        }
    }

    public void changeCanPlaySoundEffects()
    {
        canPlaySoundEffects = !canPlaySoundEffects;
    }
}
