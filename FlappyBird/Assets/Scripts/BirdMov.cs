using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BirdMov : MonoBehaviour
{
    public TMP_Text score;
    public Rigidbody2D rb;
    public int points;
    private bool die = false;
    private bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        score.text = ""+points;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) && die == false && pause == false){
            rb.velocity = new Vector2(0, 4);
            //transform.eulerAngles = new Vector3(0, 0, 45);
        }
        float y = rb.velocity.y*15;
        if (y < -45){
            y = -45;
        }
        transform.eulerAngles = new Vector3(0, 0, y);
        
        if( Input.GetKeyDown( KeyCode.P ) && die == false){
            if (pause == false){
                Time.timeScale = 0;
                pause = true;
            }else{
                Time.timeScale = 1;
                pause = false;
            }
        }
    }

    public int getPoints(){
        return points;
    }

    public bool getDie(){
        return die;
    }

    
    
    private void OnTriggerEnter2D(Collider2D  col)
    {
        if(col.gameObject.tag == "pipe"){
            die = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "point" && die == false){
            points++;
            score.text = ""+points;
        }
        
    }

   

    /*

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "pipe"){
            die = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("pipe"))
        {
            Debug.Log("GOOOOOL");
            
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            
            if (!isPlayer1Wall)
            {
                GameObject.Find("Game").GetComponent<GameManager>().setPlayer1Scores();
            }
            else
            {
                GameObject.Find("Game").GetComponent<GameManager>().setPlayer2Scores();
            }
            GameObject.Find("Game").GetComponent<GameManager>().Score();
        }
    }
    */
}
