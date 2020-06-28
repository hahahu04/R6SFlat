using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLR : MonoBehaviour
{
    public float decayTime;
    public float fadeDelta;
    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color none = new Color(lr.startColor.r, lr.startColor.g, lr.startColor.b, 0);
        lr.startColor = Color.Lerp(lr.startColor, none, fadeDelta);
        lr.endColor = Color.Lerp(lr.endColor, none, fadeDelta);
        decayTime -= 1;
        if (decayTime <= 0)
            Destroy(gameObject);
    }
}
