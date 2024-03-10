using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rino : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator ac;
    SpriteRenderer sr;
    bool facingRight;
    BoxCollider2D boxCollider;
    public LayerMask mapLayer;
    public LayerMask playerLayer;
    public float movement = 0;
    public float speed = 6;
    public float detection = 3;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.gravityScale = 5;
        ac = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isNextTohePlayer()
    {
        Vector2 directionToTest = facingRight ? Vector2.right : Vector2.left;
        var boxCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, directionToTest, detection, playerLayer);
        //Debug.Log("NextToheWall: "+boxCastHit.collider != null);
        return boxCastHit.collider != null;
    }
    public bool isNextToheWall()
    {
        Vector2 directionToTest = facingRight ? Vector2.right : Vector2.left;
        var boxCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size-(new Vector3(0,0.5f,0)), 0, directionToTest, 0.2f, mapLayer);
        //Debug.Log("NextToheWall: "+boxCastHit.collider != null);
        return boxCastHit.collider != null;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isNextToheWall()){
            movement = 0;
            ac.SetTrigger("Hit");
            Destroy(this);
        }else if (isNextTohePlayer()){
            movement = -1;
            ac.SetTrigger("Run");
            
        }
    }
}
