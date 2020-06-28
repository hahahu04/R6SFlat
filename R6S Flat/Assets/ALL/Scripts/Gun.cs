using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletLR;
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
    //[HideInInspector]
    public int magSize_counter;
    [Tooltip("(SECONDS)")]
    public float reloadSpeed;
    [HideInInspector]
    public float reloadSpeed_timer;

    [Tooltip("SMG, Rifle, Pistol, MG, Shotgun, Electric, None")]
    public string ammoType;

    public bool fullAuto;

    [HideInInspector]
    public bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        magSize_counter = magSize;
        reloadSpeed_timer = reloadSpeed;
    }

    private void Update()
    {
        if (magSize_counter <= 0 || Input.GetKeyDown("r"))
            reloading = true;

        if (reloading)
        {
            reloadSpeed_timer -= Time.deltaTime;
            if (reloadSpeed_timer <= 0)
            {
                magSize_counter = magSize;
                reloadSpeed_timer = reloadSpeed;
                reloading = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (fullAuto)
        {
            if (Input.GetMouseButton(0) && fireRate_timer <= 0 && !reloading)
            {
                float temp_ao = accuracyOffset * UTIL.FastDist(transform.position, UTIL.MousePos(), 0.1f);

                Vector3 targetPos = UTIL.MousePos() + new Vector3(Random.Range(-temp_ao, temp_ao), Random.Range(-temp_ao, temp_ao));
                Vector3 fireDir = targetPos - transform.position;
                RaycastHit2D shot = Physics2D.Raycast(barrelEnd.position, fireDir, distance, hitLayers);
                if (shot.collider != null)
                {
                    if (damageLayers == (damageLayers | (1 << shot.collider.gameObject.layer)))
                    {
                        //Debug.Log("hit");
                    }
                    //Debug.Log("hit");
                    LineRenderer lr = Instantiate(bulletLR, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, shot.point);

                    fireRate_timer = fireRate;
                    magSize_counter -= 1;
                }
            }
            
        }

        fireRate_timer -= 1;
    }
}
