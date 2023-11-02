using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMov : MonoBehaviour
{
    public float vel;
    public float pos2X;
    public float pos2Y;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-vel, 0);
    }

    // Update is called once per frame
    void Update()
    {//29.09f 23.81f
        if(transform.position.x <= -pos2X){
            transform.position = new Vector3(pos2X, pos2Y,0);
        }
        
    }

    public void Stop(){
        rb.velocity = new Vector2(0, 0);
    }
    
}
