using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Passcode : MonoBehaviour
{
    [SerializeField] public int correctNumber = 2;
    [SerializeField] float flashingSpeed = 0.5f;

    [SerializeField] float flashingDelay = 0.5f;

    [SerializeField] public string defusevoice = "NiceAndSweetVoice";
     Color correctColor = Color.green;

    private float flashingtimer = 0.5f;

    [SerializeField] List<int> falseSequence;

    public bool iscorrect=false;


    private int sequenceIndex = 0;

    void Start()
    {
        flashingtimer = flashingDelay;
        initializeFalseSequence();
    }

    void Update()
    {
        flashingtimer-=Time.deltaTime;
        if(!iscorrect && flashingtimer<0)
        {
            flashingtimer = flashingSpeed;
            gameObject.GetComponent<TextMeshPro>().SetText(falseSequence[sequenceIndex].ToString());
            sequenceIndex++;
            if(sequenceIndex>falseSequence.Count-1)
            {
                sequenceIndex=0;
            }
        }

        if(iscorrect)
        {
            gameObject.GetComponent<TMP_Text>().color = correctColor;
            gameObject.GetComponent<TextMeshPro>().SetText(correctNumber.ToString());
        }
    }

    //TODO
    void initializeFalseSequence()
    {

    }
}
