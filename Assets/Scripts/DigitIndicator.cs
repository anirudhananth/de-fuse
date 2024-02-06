using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitIndicator : MonoBehaviour
{
    [SerializeField] List<GameObject> Digits;
    int digitLength;
    public GameObject CurrentDigit;

    public int digitIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        digitLength = Digits.Count;
        CurrentDigit = Digits[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentDigit.GetComponent<Passcode>().iscorrect)
        {
            moveToNextDigit();
        }
    }

    private bool moveToNextDigit()
    {
        digitIndex++;
        if(digitIndex>digitLength-1)
        {
            return false;
        }
        else
        {
            CurrentDigit = Digits[digitIndex];
            Vector3 pos=CurrentDigit.transform.position;
            pos.y = gameObject.transform.position.y;
            pos.z = gameObject.transform.position.z;
            pos.x += 0.15f;//The position of mesh using the rect position
            gameObject.transform.SetPositionAndRotation(pos,gameObject.transform.rotation);
        }
        return true;
    }

}
