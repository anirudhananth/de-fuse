using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]DigitIndicator digitIndicator;
    [SerializeField]Timer timer;
    [SerializeField]GameObject currentDigit;
    void Start()
    {
        digitIndicator = FindFirstObjectByType<DigitIndicator>();
        timer = FindFirstObjectByType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDigit = digitIndicator.CurrentDigit;
    }

    public void ButtonPressed(int value)
    {
        if(value == currentDigit.GetComponent<Passcode>().correctNumber)
        {
            //If the button Pressed is Correct
            currentDigit.GetComponent<Passcode>().iscorrect=true;

        }
        else
        {
            //If the button Pressed is Wrong
            timer.timerSetHalf();
        }
    }
}
