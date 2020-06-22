using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInSight : MonoBehaviour
{
    private SpriteRenderer sr;
    public Transform target;
    public LayerMask wallLayers;
    public float maxDist;
    public bool useAnim;
    private Animator anim;

    public Transform[] raycastPos;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (useAnim)
            anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool inSight = false;

        foreach(Transform pos in raycastPos)
        {
            RaycastHit2D cast = Physics2D.Raycast(pos.position, target.position - pos.position, UTIL.FastDist(target.position, pos.position, 0.05f), wallLayers);
            Debug.DrawRay(pos.position, target.position - pos.position);
            if (cast.collider == null && UTIL.FastDist(target.position, pos.position, 0.05f) <= maxDist)
                inSight = true;
        }
        if (useAnim)
        {
            if (inSight)
                anim.SetBool("InSight", true);
            else
                anim.SetBool("InSight", false);
        }
        else
        {
            if (inSight)
                sr.enabled = true;
            else
                sr.enabled = false;
        } 
    }
}
