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
}
