using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float xaxis;
    private float yaxis;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        xaxis = Input.GetAxisRaw("Horizontal") * speed;
        yaxis = Input.GetAxisRaw("Vertical") * speed;
        //Move with X = Left right
        Vector2 Velocity = rb.velocity;
        Velocity = new Vector2(xaxis, yaxis);
        rb.velocity = Velocity;

        //Max Movement spd
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity *= speed / rb.velocity.magnitude;
        }
        if (transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
