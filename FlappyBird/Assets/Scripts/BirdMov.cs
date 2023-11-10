using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using System.Linq;

public class BirdMov : MonoBehaviour
{
    public GameObject pauseImage;
    public GameObject miniGoldPrefab;
    private GameObject[] arrayGolds = new GameObject[9];
    public float separateGolds = 1f;
    public float goldY = 4.2f;
    public float goldX = -8.5f;
    public TMP_Text score;
    public TMP_Text end;
    public string endText;
    public TMP_Text paintStart;
    public Rigidbody2D rb;
    public int points = 0;
    private bool die = false;
    private bool pause = false;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        endText = end.text;
        end.text = "";
        for(int i = 0; i<9;i++){
            GameObject ins = Instantiate(miniGoldPrefab, new Vector3(goldX,(goldY-separateGolds*i),0), transform.rotation);
            arrayGolds[i]= ins;
            ins.SetActive(false);
        }
        pauseImage.SetActive(false);
        rb.gravityScale = 0f;
        score.text = ""+points;
    }

    // Update is called once per frame
    void Update()
    {
        if(die == false){
            if( Input.GetKeyDown( KeyCode.Space ) && pause == false){
                start = true;
                paintStart.enabled = false;
                rb.gravityScale = 1f;
                rb.velocity = new Vector2(0, 4);
            }
            float y = rb.velocity.y*15;
            if (y < -45){
                y = -45;
            }
            transform.eulerAngles = new Vector3(0, 0, y);
        
            if( Input.GetKeyDown( KeyCode.P )){
                if (pause == false){
                    Time.timeScale = 0;
                    pause = true;
                    pauseImage.SetActive(true);
                }else{
                    Time.timeScale = 1;
                    pause = false;
                    pauseImage.SetActive(false);
                }
            }
        }else{
            Die();
            if( Input.GetKeyDown( KeyCode.Space )){
                
            }
        }
    }

    public void Restart(){
        die = false;
        start = false;
        points = 0;
        end.text = "";
        score.text = ""+points;
        paintStart.enabled = true;
        for(int i = 0; i<9;i++){
            arrayGolds[i].SetActive(false);
        }
    }

    public int getPoints(){
        return points;
    }
    public bool getStart(){
        return start;
    }
    public bool getDie(){
        return die;
    }
    public void Die(){
        end.text =endText+" "+points+"\n Presiona \"Espacio\" para reiniciar";
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
            if(points > 0 && (points%5) == 0){
                if((points/5) <10){
                    arrayGolds[(points/5)-1].SetActive(true);
                }
            }
        }
    }
}
