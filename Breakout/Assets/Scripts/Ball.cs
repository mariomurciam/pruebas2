using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameManager gm;
    public float speed = 5;
    private float incialSpeed;
    public Rigidbody2D rb;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        incialSpeed = speed;
        Launch();
    }

    public void Faster()
    {
        speed++;
        rb.velocity *= (speed / (speed - 1.00f));
    }

    public void ResetSpeed()
    {
        speed = incialSpeed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Faster();
        }
        if (col.gameObject.tag == "wall")
        {
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
        }
    }
    public void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Floor")
        {
            transform.position = startPosition;
            Launch();
            gm.SwapLives(false);
        }
    }

    public void Launch()
    {
        float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float y = 1;  //UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x * speed, y * speed);
    }

    public void Reset()
    {
        //start = false;
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        ResetSpeed();
        rb.velocity = new Vector2(0, 0);
        //Launch();
    }
}
