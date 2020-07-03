using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float magnitude;
    public Transform camPos;
    Vector2 initPos;

    [HideInInspector]
    public bool shake;

    [HideInInspector]
    public float shakeDuration;
    public float shakeDuration_default;
    // Start is called before the first frame update
    void Start()
    {
        initPos = camPos.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shake)
        {
            Vector2 movePos = initPos;
            movePos += new Vector2(Random.Range(-magnitude, magnitude), Random.Range(-magnitude, magnitude));
            camPos.localPosition = movePos;
        }
        else
            camPos.localPosition = initPos;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            shake = true;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shake = false;
            shakeDuration = 0;
        }
    }

    public void Shake(bool shake)
    {
        Debug.Log(2);

        if (shake)
            shake = true;
        else
            shake = false;
    }
    public void Shake(float duration)
    {
        shake = true;
        if(duration != -1)
        {
            shakeDuration = duration;
        }
        else
        {
            shakeDuration = shakeDuration_default;
        }
    }
}
