using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public LineRenderer lr;
    public Color bulletColor;
    public Transform barrelEnd;
    public float damage;
    public float accuracyOffset;
    public float fireRate;
    [Tooltip("Must be long enought to hit at least something")]
    public float distance = 99;
    public LayerMask hitLayers;
    public LayerMask damageLayers;
    [HideInInspector]
    public float fireRate_timer;
    public int magSize;
    [HideInInspector]
    public int magSize_counter;

    [Tooltip("SMG, Rifle, Pistol, MG, Shotgun, Electric, None")]
    public string ammoType;

    public bool fullAuto;

    // Start is called before the first frame update
    void Start()
    {
        magSize_counter = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (fullAuto)
        {
            if (Input.GetMouseButton(0) && magSize_counter > 0 && fireRate_timer <= 0)
            {
                Vector3 fireDir = Vector2.right;
                fireDir.z += Random.Range(-accuracyOffset, accuracyOffset);
                RaycastHit2D shot = Physics2D.Raycast(barrelEnd.position, fireDir, distance, hitLayers);

                if (shot.collider != null)
                {
                    if (damageLayers == (damageLayers | (1 << shot.collider.gameObject.layer)))
                    {
                        Debug.Log("hit");
                    }

                    lr.
                }
            }
        }
        
    }
}
