using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5;
    private float incialSpeed;
    public Rigidbody2D rb;
    private Vector3 startPosition;
    public bool start;

    // Start is called before the first frame update
    void Start()
    {
        start = true;
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
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    private void Launch()
    {
        float x = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float y = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x * speed, y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            Debug.Log("Space key was pressed.");
            Launch();
            start = true;
        }
        */

    }

    public void Reset()
    {
        //start = false;
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        ResetSpeed();
        Launch();
    }
}
