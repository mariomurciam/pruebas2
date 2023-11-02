using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMov : MonoBehaviour
{//24
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= -23.81f){
            transform.position = new Vector3(23.81f, -3,0);
        }
        
    }
}
