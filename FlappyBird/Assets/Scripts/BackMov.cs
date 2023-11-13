using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMov : MonoBehaviour
{
    public float vel;
    public float pos2X;
    public float pos2Y;
    private bool stop;
    // Start is called before the first frame update
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {//29.09f 23.81f
        if(transform.position.x <= -pos2X){
            transform.position = new Vector3(pos2X, pos2Y,0);
        }
        if(stop == false){
            transform.Translate(Vector3.left*Time.deltaTime*vel);
        }
        
        
    }

    public void Stop(){
        stop = true;
    }

    public void Restart(){
        stop = false;
    }
    
}
