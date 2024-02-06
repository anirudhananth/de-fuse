using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] GameObject graphicsUI;
    [SerializeField] GameObject nonGraphicsUI;
    bool isGraphicsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Play("Sparks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleGraphics() {
        isGraphicsOn = !isGraphicsOn;
        graphicsUI.SetActive(isGraphicsOn);
        nonGraphicsUI.SetActive(!isGraphicsOn);
    }
}
