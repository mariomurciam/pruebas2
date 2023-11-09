using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject bird;
    private BirdMov birdMov;
    public GameObject spawn;
    public GameObject back1;
    public GameObject back2;
    public GameObject floor1;
    public GameObject floor2;
    private float timeRemaining;
    private bool die = false;
    void Awake(){
        birdMov = bird.GetComponent<BirdMov>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        timeRemaining = 0; //UnityEngine.Random.Range(2.00f, 3.00f);
    }

    // Update is called once per frame
    void Update()
    { 
        if(birdMov.getDie() == true && die == false){
            Die();
        }
        if (die == false){
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }else{
                //StartPipe();
                timeRemaining = UnityEngine.Random.Range(2.00f, 3.00f);
                //Destroy(ins, 10.00f);
            }
        }
        
        
    }

    

    void Die(){
        die = true;
        back1.GetComponent<BackMov>().Stop();
        back2.GetComponent<BackMov>().Stop();
        floor1.GetComponent<BackMov>().Stop();
        floor2.GetComponent<BackMov>().Stop();
    }

    public bool getDie(){
        return die;
    }

    

}
