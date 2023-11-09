using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    private int player1Scores;
    private int player2Scores;
    public TMP_Text score_table;
    public TMP_Text mess_winner;
    public GameObject help;
    public int max_score = 5;
    private bool end = false;

    public void Score()
    {
        score_table.text = player2Scores+"-"+player1Scores;
        //.transform.localScale x y z
        Debug.Log(player2Scores+" - "+player1Scores);
        if (player1Scores >= max_score || player2Scores >= max_score){
            if (player1Scores >= max_score){
                mess_winner.text += "\n Gana jugador 1";
            }
            if (player2Scores >= max_score){
                mess_winner.text += "\n Gana jugador 2";
            }
            help.SetActive(true);
            end = true;
        }else{
            Reset();
        }
        
    }
    public void Reset(){
        player1.transform.localScale =new Vector3(player1.transform.localScale.x , 4.00f, player1.transform.localScale.y );
        player2.transform.localScale =new Vector3(player2.transform.localScale.x , 4.00f , player2.transform.localScale.y );
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Paddle>().Reset();
        player2.GetComponent<Paddle>().Reset();
    }

    public int getPlayer1Scores(){
        return player1Scores;
    }
    public int getPlayer2Scores(){
        return player2Scores;
    }
    public void setPlayer1Scores(){
        player1Scores++;
        if(player2.transform.localScale.y <8){
            player1.transform.localScale =new Vector3(player1.transform.localScale.x , player1.transform.localScale.y - 1.00f , player1.transform.localScale.y );
            player2.transform.localScale =new Vector3(player2.transform.localScale.x , player2.transform.localScale.y + 1.00f , player2.transform.localScale.y );
        }
    }
    public void setPlayer2Scores(){
        player2Scores++;
        if (player1.transform.localScale.y <8){
            player1.transform.localScale =new Vector3(player1.transform.localScale.x , player1.transform.localScale.y + 1.00f , player1.transform.localScale.y );
            player2.transform.localScale =new Vector3(player2.transform.localScale.x , player2.transform.localScale.y - 1.00f , player2.transform.localScale.y );
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score_table.text = "0-0";
        mess_winner.text = "";
        help.SetActive(false);
        player1Scores = 0;
        player2Scores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.R ) && end == true ){
            Debug.Log( "Space key was pressed." );
            score_table.text = "0-0";
            mess_winner.text = "";
            help.SetActive(false);
            player1Scores = 0;
            player2Scores = 0;
            end = false;
            Reset();
        }
    }
}
