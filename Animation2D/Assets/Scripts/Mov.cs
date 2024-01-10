using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 6;
    public float movement;
    public int max_jump;
    private int jumps;
    float movement_jump;
    // Start is called before the first frame update
    void Start()
    {
        jumps = 0;
    }

    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Jump") > 0)
        {
            movement_jump = Input.GetAxisRaw("Jump") * (speed * 2);
        }
        else
        {
            movement_jump = rb.velocity.y;
        }


        rb.velocity = new Vector2(movement * speed, movement_jump);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
