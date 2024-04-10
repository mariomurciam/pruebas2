using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 8;
    public float movX;
    public float movY;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed * movX, speed * movY, rb.velocity.z);
    }

    // Update is called once per frame
    void Update()
    {
        movX = -Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");
    }
}
