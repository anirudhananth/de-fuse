using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    bool isbombdefused;
    bool isactive;
    [SerializeField] float fadingSpeed = 0.7f;
    [SerializeField] GameObject FinalResult;
    float flashingtimer;
    bool isFadeComplete=true;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFadeComplete && gameObject.activeInHierarchy)
        {
            fade();
        }
        else
        {
            if(!FinalResult.activeInHierarchy)
            {
                FinalResult.SetActive(true);
            }
        }
    }
    public void bombDefusedEnd()
    {
        gameObject.SetActive(true);
        FinalResult.SetActive(false);
        flashingtimer = fadingSpeed;
        Color c =gameObject.GetComponent<Image>().color;
        c.a=0;
        gameObject.GetComponent<Image>().color = c;
        isFadeComplete=false;

        FinalResult.GetComponent<TMP_Text>().SetText("Bomb Defused");
        FinalResult.GetComponent<TMP_Text>().color= Color.green;
        //TODO:play bomb defuse end sound

        FindFirstObjectByType<AudioManager>().Play("BombDefuseAudioreport");
        FindFirstObjectByType<AudioManager>().Pause("Heli");
        FindFirstObjectByType<AudioManager>().Pause("Sparks");
    }

    public void bombExplodeEnd()
    {
        gameObject.SetActive(true);
        FinalResult.SetActive(false);
        flashingtimer = fadingSpeed;
        Color c =gameObject.GetComponent<Image>().color;
        c.a=0;
        gameObject.GetComponent<Image>().color = c;
        isFadeComplete=false;

        FinalResult.GetComponent<TMP_Text>().SetText("Bomb Exploded");
        FinalResult.GetComponent<TMP_Text>().color = Color.red;
        //TODO:Play bomb explosion end sound
        FindFirstObjectByType<AudioManager>().Play("BombExplodeAndReport");
        FindFirstObjectByType<AudioManager>().Pause("Heli");
        FindFirstObjectByType<AudioManager>().Pause("Sparks");
        FindFirstObjectByType<AudioManager>().Pause("Beep");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    void fade()
    {
        flashingtimer-=Time.deltaTime;
        if(flashingtimer<0)
        {
            flashingtimer=0;
            isFadeComplete=true;
        }
        float alpha = 255*(fadingSpeed-flashingtimer)/fadingSpeed;
        Color32 c = gameObject.GetComponent<Image>().color;
        c.a = (byte)alpha;
        gameObject.GetComponent<Image>().color = c;
    }
}
