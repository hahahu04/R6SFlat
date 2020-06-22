using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Current speed: walk, sprint etc")]
    public float speed;
    public float speed_walk;
    public float speed_crouch;
    public float speed_sprint;
    public float speed_dying;

    public float rotSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void LookAtMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = mousePos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotSpeed);
    }


    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftControl))
            speed = speed_crouch;
        else if (Input.GetKey(KeyCode.LeftShift))
            speed = speed_sprint;
        else
            speed = speed_walk;

        Vector2 movePos = transform.position;
        movePos.x += x * speed;
        movePos.y += y * speed;

        rb.MovePosition(movePos);
        LookAtMouse();
    }
}
