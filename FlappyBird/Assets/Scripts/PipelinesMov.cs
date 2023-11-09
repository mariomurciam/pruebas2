using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelinesMov : MonoBehaviour
{
    public GameObject pipeUp;
    public GameObject pipeDown;
    public GameObject point;
    private float positionX;
    private float pipeDownY;
    private float pipeUpY;
    private float timeRemaining = 10.00f;
    private GameManager gameManager;
    public float separate = 0.9f;
    public int vel = 4;
    
    // Start is called before the first frame update
    void Awake(){
        
        positionX = transform.position.x;
        //Debug.Log("X:  "+positionX);
        gameManager = GetComponentInParent<GameManager>();
        pipeDownY = pipeDown.transform.position.y;
        pipeUpY = pipeUp.transform.position.y;
    }

    void Start()
    {
        
        //Debug.Log("D: "+pipeDownY+" ----- P:"+pipeUpY);
        //RandomPoint();
    }
    void OnEnable(){
        transform.position = new Vector3(positionX, UnityEngine.Random.Range(-2.50f, 2.50f), 0);

        //Debug.Log("OOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
        RandomPoint();
    }

    // Update is called once per frame
    void Update()
    {//-14.6
        if (gameManager.getDie() == false){

            transform.Translate(Vector3.left*Time.deltaTime*vel);

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }else{
                gameObject.SetActive(false);
                timeRemaining = 10.00f;
            }
            
            
        }
        
    }

   
    private void RandomPoint(){
        pipeDown.transform.position = new Vector3(pipeDown.transform.position.x, pipeDownY, 0);
        pipeUp.transform.position = new Vector3(pipeUp.transform.position.x, pipeUpY, 0);
        //Debug.Log("D: "+pipeDownY+" ----- P:"+pipeUpY);
        if (transform.position.y >0){
            pipeDown.transform.position = new Vector3(pipeDown.transform.position.x, pipeDownY + UnityEngine.Random.Range(-separate, (separate/2)), 0);
        }else{
            pipeUp.transform.position = new Vector3(pipeUp.transform.position.x, pipeUpY + UnityEngine.Random.Range(-(separate/2), separate), 0);
        }
    }

}
