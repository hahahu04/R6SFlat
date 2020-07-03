using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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

    public static GameObject GetPlayer()
    {
        return (GameObject.FindGameObjectWithTag("Player"));
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

    public static Vector3 MousePos()
    {
        return (Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
