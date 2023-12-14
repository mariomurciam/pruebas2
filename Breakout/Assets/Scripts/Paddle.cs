using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    public float speed = 4;
    public Rigidbody2D rb;
    public float movement;
    private Vector3 startPosition;

    private void Awake()
    {

    }
    private void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Ball")
        {
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(movement * speed, 0);

    }

    public void Reset()
    {
        transform.position = startPosition;
    }
}
