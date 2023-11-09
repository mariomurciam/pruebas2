using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;

    private float movement;
    private Vector3 startPosition;


    private void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Ball"){
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
