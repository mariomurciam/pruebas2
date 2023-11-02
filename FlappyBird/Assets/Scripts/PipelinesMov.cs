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
        RandomPoint();
        rb.velocity = new Vector2(-4, 0);
    }

    // Update is called once per frame
    void Update()
    {//-14.6
        if(transform.position.x <= -26.60f){
            RestartPosition();
        }
        
    }

    public void Stop(){
        rb.velocity = new Vector2(0, 0);
    }

    public void RestartPosition(){
        transform.position = new Vector3(13.30f, UnityEngine.Random.Range(-2.00f, 2.00f), 0);
        RandomPoint();
        rb.velocity = new Vector2(-4, 0);
    }

    private void RandomPoint(){
        if (transform.position.y >0){
            pipeDown.transform.position = new Vector3(pipeDown.transform.position.x, pipeDown.transform.position.y + UnityEngine.Random.Range(-0.60f, 0.60f), 0);
        }else{
            pipeUp.transform.position = new Vector3(pipeUp.transform.position.x, pipeUp.transform.position.y + UnityEngine.Random.Range(-0.60f, 0.60f), 0);
        }
    }

}
