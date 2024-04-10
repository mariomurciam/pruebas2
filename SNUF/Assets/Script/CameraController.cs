using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 8;
    public float movX;
    public float movZ;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void FixedUpdate() {
        rb.velocity = new Vector3(speed * movX, rb.velocity.y, speed * movZ);
    }

    // Update is called once per frame
    void Update()
    {
        movX = -Input.GetAxisRaw("Horizontal");
        movZ = -Input.GetAxisRaw("Vertical");
    }
}
