using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;
    Animator ac;
    SpriteRenderer sr;
    public float speed = 6;
    public float movement;
    public int max_jump = 2;
    public int jumps;
    public bool jump = false;
    public bool mov = false;
    float movement_jump;
    bool facingRight;
    BoxCollider2D boxCollider;
    public LayerMask mapLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.gravityScale = 5;
        ac = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        jumps = 0;
    }

    bool isGrounded()
    {
        var boxCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.05f, mapLayer);
        return boxCastHit.collider != null;
    }

    bool isNextToheWall()
    {
        Vector2 directionToTest = facingRight ? Vector2.right : Vector2.left;
        var boxCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, directionToTest, 0.1f, mapLayer);
        return boxCastHit.collider != null;
    }

    void FixedUpdate()
    {
        if (jump == true)
        {
            movement_jump = (speed * 3);
            rb.velocity = new Vector2(rb.velocity.x, movement_jump);
            //rb.AddForce(Vector2.up * speed * 2 * (jumps), ForceMode2D.Impulse);
            jump = false;
            jumps++;
            if (jumps > 1)
            {
                ac.SetBool("DoubleJump", true);
            }
            else
            {
                ac.SetTrigger("Jump");
            }
        }
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        if (movement == 1)
        {
            facingRight = true;
            sr.flipX = false;
        }
        if (movement == -1)
        {
            facingRight = false;
            sr.flipX = true;
        }
        if (rb.velocity.y < 0 && isGrounded() == false)
        {
            ac.SetBool("DoubleJump", false);
            ac.SetBool("Falling", true);
        }
        if (isNextToheWall() && isGrounded() == false)
        {
            ac.SetBool("WallJump", true);
        }

        if (isGrounded() && jump == false)
        {
            ac.SetBool("DoubleJump", false);
            jumps = 0;
            ac.SetBool("Falling", false);
            ac.SetBool("OnFloor", true);
        }
        else
        {
            ac.SetBool("OnFloor", false);
        }
        movement_jump = 0;
        if ((Input.GetKeyDown(KeyCode.Space)) && jumps < max_jump)
        {
            movement_jump = (speed * 2);
            jump = true;

        }





        if (Input.GetKeyDown(KeyCode.M))
        {
            jumps = 0;
        }
        ac.SetBool("Run", movement != 0);
    }
}
