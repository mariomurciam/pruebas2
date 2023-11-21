using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public bool ia;
    public GameObject ball;
    public float speed;
    public Rigidbody2D rb;
    private float movement;
    private Vector3 startPosition;
    private Vector3 startScale;
    private void Start()
    {
        startPosition = transform.position;
        startScale = transform.localScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ball")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ia == true){
            if (ball.transform.position.y > gameObject.transform.position.y)
        {
            movement = 1f;
        }
        else
        {
            if (ball.transform.position.y < gameObject.transform.position.y){
                movement = -1f;
            }else{
                movement = 0f;
            }
            
        }
        }else{
            if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        }
        

        rb.velocity = new Vector2(0, movement * speed);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        transform.localScale = startScale;
    }
}
