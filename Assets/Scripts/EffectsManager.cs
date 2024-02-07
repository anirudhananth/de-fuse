using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] GameObject graphicsUI;
    [SerializeField] GameObject nonGraphicsUI;
    [SerializeField] Animator simpleAnimator;
    [SerializeField] Animator graphicAnimator;
    bool isGraphicsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Play("Sparks");
        // FindFirstObjectByType<AudioManager>().Play("Breathing");
        StartCoroutine(PlayBreathing());
    }

    IEnumerator PlayBreathing() {
        yield return new WaitForSeconds(2);
        FindFirstObjectByType<AudioManager>().Play("Breathing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleGraphics() {
        isGraphicsOn = !isGraphicsOn;
        graphicsUI.SetActive(isGraphicsOn);
        nonGraphicsUI.SetActive(!isGraphicsOn);
        FindFirstObjectByType<AudioManager>().Stop("Breathing");
        StartCoroutine(PlayBreathing());
    }

    public void toggleAnimator() {
        if(isGraphicsOn) {
            if(graphicAnimator.enabled == false) {
                graphicAnimator.enabled = true;
            } else {
                graphicAnimator.enabled = false;
            }
        } else {
            if(simpleAnimator.enabled == false) {
                simpleAnimator.enabled = true;
            } else {
                simpleAnimator.enabled = false;
            }
        }
    }
}
