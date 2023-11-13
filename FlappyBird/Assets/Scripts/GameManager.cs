using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject bird;
    private BirdMov birdMov;
    public GameObject spawn;
    public GameObject back1;
    public GameObject back2;
    public GameObject floor1;
    public GameObject floor2;
    private bool die = false;
    private bool start = false;

    void Awake(){
        spawn.SetActive(false);
        birdMov = bird.GetComponent<BirdMov>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(birdMov.getDie() == true && die == false){
            Die();
        }
        if (start == false){
            if(birdMov.getStart() == true){
                start = true;
                spawn.SetActive(true);
            }
        }
    }

    public void Restart(){
        die = false;
        start = false;
        back1.GetComponent<BackMov>().Restart();
        back2.GetComponent<BackMov>().Restart();
        floor1.GetComponent<BackMov>().Restart();
        floor2.GetComponent<BackMov>().Restart();
        spawn.SetActive(false);
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
