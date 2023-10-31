using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelinesMov : MonoBehaviour
{
    public GameObject pipeUp;
    public GameObject pipeDown;
    public GameObject point;
    public Rigidbody2D rb;
    //private float timeRemaining = 1.00f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-4, 0);
    }

    // Update is called once per frame
    void Update()
    {//-14.6
        if(transform.position.x <= -26.60f){
            transform.position = new Vector3(13.30f, UnityEngine.Random.Range(-2.00f, 2.00f),0);
        }
        
    }

    private void RestartPosition(){
        transform.position = new Vector3(6.30f, UnityEngine.Random.Range(-2.00f, 2.00f), 0);
    }
}
