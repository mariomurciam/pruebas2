using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelinesMov : MonoBehaviour
{
    public GameObject pipeUp;
    public GameObject pipeDown;
    public GameObject point;
    private float positionX;
    private Vector3 pipeDownIncialPosition;
    private Vector3 pipeUpIncialPosition;
    private float timeRemaining = 10.00f;
    private GameManager gameManager;
    public float separate = 0.9f;
    public float minY = -1.80f;
    public float maxY = 2.50f;
    public int vel = 4;
    
    // Start is called before the first frame update
    void Awake(){
        
        positionX = transform.position.x;
        gameManager = GetComponentInParent<GameManager>();
        pipeDownIncialPosition = pipeDown.transform.localPosition;
        pipeUpIncialPosition = pipeUp.transform.localPosition;
    }
    void OnEnable(){
        timeRemaining = 10.00f;
        transform.position = new Vector3(positionX, UnityEngine.Random.Range(minY, maxY), 0);
        RandomPoint();
    }

    // Update is called once per frame
    void Update()
    {
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
        pipeUp.transform.localPosition = pipeUpIncialPosition;
        pipeDown.transform.localPosition = pipeDownIncialPosition;
        if (transform.position.y >0){
            pipeDown.transform.position += new Vector3(0, UnityEngine.Random.Range(-separate, (separate/2)), 0);
        }else{
            pipeUp.transform.position += new Vector3(0, UnityEngine.Random.Range(-(separate/2), separate), 0);
        }
    }

}
