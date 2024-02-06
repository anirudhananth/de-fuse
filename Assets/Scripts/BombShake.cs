using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShake : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] GameObject playerHand;
    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 _oldPosition = transform.localPosition;
        Vector3 _oldScreenPosition = screen.transform.localPosition;
        Vector3 _oldPlayerHandPosition = playerHand.transform.localPosition;

        float time = 0.0f;
        while (time < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, _oldPosition.z);
            screen.transform.localPosition = new Vector3(x, y, _oldScreenPosition.z);
            playerHand.transform.localPosition = new Vector3(x, y, _oldPlayerHandPosition.z);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _oldPosition;
        screen.transform.localPosition = _oldScreenPosition;
        playerHand.transform.localPosition = _oldPlayerHandPosition;
    }
   
    public void SevereShake() {
        StartCoroutine(Shake(.3f, .55f));
    }

    public void SmallerShake() {
        StartCoroutine(Shake(.05f, .15f));
    }
}
