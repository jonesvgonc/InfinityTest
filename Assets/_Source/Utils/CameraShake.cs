using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    public void Awake()
    {
        Instance = this;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        var originalPos = transform.localPosition;
        var elapsed = 0f;
        while(elapsed < duration)
        {
            var x = Random.Range(-0.5f, 0.5f) + magnitude;
            float y = Random.Range(-0.5f, 0.5f) + magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            yield return null;
            elapsed += Time.deltaTime;
        }

        transform.localPosition = originalPos;
    }
}
