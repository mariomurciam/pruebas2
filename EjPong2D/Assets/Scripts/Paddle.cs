using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class Paddle : NetworkBehaviour
{
    public bool isPlayer1;
    public bool ia;
    public GameObject ball;
    public float speed = 4;
    public Rigidbody2D rb;
    public float movement;
    private Vector3 startPosition;
    private Vector3 startScale;
    public bool onAtc = false;
    private AutoPaddleFSM fmsPaddle;
    private void Awake()
    {
        fmsPaddle = null;
    }
    public void StartIA()
    {
        fmsPaddle = new AutoPaddleFSM(this);
        ia = true;
    }
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
        if (ia == false)
        {
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

    void Update()
    {
        if (ia == true && fmsPaddle != null)
        {
            fmsPaddle.Update();
        }

    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        transform.localScale = startScale;
    }
    public void Reposition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
