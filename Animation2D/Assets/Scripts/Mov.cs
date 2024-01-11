using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 6;
    public float movement;
    public int max_jump = 2;
    public int jumps;
    public bool jump = false;
    public bool mov = false;
    float movement_jump;
    // Start is called before the first frame update
    void Start()
    {
        jumps = 0;
    }

    void FixedUpdate()
    {
        if (jump == true)
        {
            //rb.velocity = new Vector2(rb.velocity.x, movement_jump);
            rb.AddForce(Vector2.up * speed * 2 * (jumps), ForceMode2D.Impulse);
            jump = false;
        }
        if (mov == true)
        {
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            mov = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            mov = true;
        }
        movement_jump = 0;
        if (Input.GetKeyDown(KeyCode.Space) && jumps < max_jump)
        {
            movement_jump = (speed * 2);
            jumps++;
            jump = true;
            mov = true;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            jumps = 0;
        }
    }
}
