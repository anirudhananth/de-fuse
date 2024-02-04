using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraShake : MonoBehaviour {
   
    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 _oldPosition = transform.localPosition;
        float time = 0.0f;
        while (time < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, _oldPosition.z);
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _oldPosition;
    }
   
    public void SevereShake() {
        StartCoroutine(Shake(.3f, .55f));
    }

    public void SmallerShake() {
        StartCoroutine(Shake(.15f, .4f));
    }
}