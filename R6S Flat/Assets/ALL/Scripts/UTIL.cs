using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTIL : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static float FastDist(Vector2 pos1, Vector2 pos2, float step)
    {
        float distSqr = (pos1.x - pos2.x) * (pos1.x - pos2.x) + (pos1.y - pos2.y) * (pos1.y - pos2.y);
        for(float f = 0f; f < 99f; f += step)
        {
            if (f*f >= distSqr)
                return (f);
        }
        return (-1);
    }
}
