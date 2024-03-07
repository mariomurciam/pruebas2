using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator ac;
    SpriteRenderer sr;
    public float speed = 6;
    public float movement;
    public int max_jump = 2;
    public int jumps;
    public bool jump = false;
    public bool mov = false;
    public float movement_jump;
    bool facingRight;
    BoxCollider2D boxCollider;
    public LayerMask mapLayer;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.gravityScale = 5;
        //ac = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        jumps = 0;
    }

    

    public bool isGrounded()
    {
        //Debug.Log("GROUNDED");
        var boxCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.05f, mapLayer);
        return boxCastHit.collider != null;
    }

    public bool isNextToheWall()
    {
        Vector2 directionToTest = facingRight ? Vector2.right : Vector2.left;
        var boxCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, directionToTest, 0.5f, mapLayer);
        //Debug.Log("NextToheWall: "+boxCastHit.collider != null);
        return boxCastHit.collider != null;
    }

    void FixedUpdate()
    {
        if (jump == true)
        {
            movement_jump = (speed * 3);
            rb.velocity = new Vector2(rb.velocity.x, movement_jump);
            jump = false;
            jumps++;
            if (jumps > 1)
            {
                ac.SetTrigger("DoubleJump");
            }
            else
            {
                ac.SetTrigger("Jump");
            }
        }
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    // Update is called once per frame
    private void Update()
    {
        if(isNextToheWall() == true){
            Debug.Log("SI");
        }else{
            Debug.Log("NO");
        }
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            jumps = 0;
        }
        ac.SetBool("Run", movement != 0);
        gm.fms.Update();
    }
}
