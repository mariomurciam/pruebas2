using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelinesMov : MonoBehaviour
{
    public GameObject pipeUp;
    public GameObject pipeDown;
    public GameObject point;
    public Rigidbody2D rb;
    private float positionX;
    private float timeRemaining;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Awake(){
        positionX = transform.position.x;
        gameManager = GetComponentInParent<GameManager>();
    }

    void Start()
    {
        RandomPoint();
        rb.velocity = new Vector2(-4, 0);
    }
    void OnEnable(){
        transform.position = new Vector3(positionX, UnityEngine.Random.Range(-1.50f, 1.50f), 0);
        RandomPoint();
        rb.velocity = new Vector2(-4, 0);
    }

    // Update is called once per frame
    void Update()
    {//-14.6
        if (gameManager.getDie() == false){
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }else{
                gameObject.SetActive(false);
                timeRemaining = 10.00f;
            }
        }
        
    }

    public void Stop(){
        rb.velocity = new Vector2(0, 0);
    }

    private void RandomPoint(){
        if (transform.position.y >0){
            pipeDown.transform.position = new Vector3(pipeDown.transform.position.x, pipeDown.transform.position.y + UnityEngine.Random.Range(-0.60f, 0.60f), 0);
        }else{
            pipeUp.transform.position = new Vector3(pipeUp.transform.position.x, pipeUp.transform.position.y + UnityEngine.Random.Range(-0.60f, 0.60f), 0);
        }
    }

}
