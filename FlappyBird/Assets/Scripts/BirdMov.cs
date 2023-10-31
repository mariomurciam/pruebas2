using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMov : MonoBehaviour
{
    public Rigidbody2D rb;
    public int points;
    private bool die = false;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) && die == false){
            rb.velocity = new Vector2(0, 4);
            //transform.eulerAngles = new Vector3(0, 0, 45);
        }
        float y = rb.velocity.y*15;
        if (y < -45){
            y = -45;
        }
        transform.eulerAngles = new Vector3(0, 0, y);

    }

    
    
    private void OnTriggerEnter2D(Collider2D  col)
    {
        if(col.gameObject.tag == "pipe"){
            die = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        points++;
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
