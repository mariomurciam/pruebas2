using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    public int player1Scores { get; private set; }
    public int player2Scores { get; private set; }
    public TMP_Text score_table;
    public TMP_Text mess_winner;
    public GameObject help;
    private FMS fms;
    public bool newPoint = false;
    [SerializeField] private float increasePaddle = 1.00f;
    [SerializeField] private float maxPaddle = 7.00f;
    [SerializeField] private int max_score = 5;
    //private bool end = false;


    public void Score()
    {
        score_table.text = player2Scores + "-" + player1Scores;
        Debug.Log(player2Scores + " - " + player1Scores);
        if (player1Scores < max_score && player2Scores < max_score)
        {
            Reset();
            newPoint = true;
        }

    }
    public void Winner()
    {
        if (player1Scores >= max_score)
        {
            if (player1.GetComponent<Paddle>().ia == true)
            {
                mess_winner.text += "\n Gana IA 1";
            }
            else
            {
                mess_winner.text += "\n Gana jugador 1";
            }
        }
        if (player2Scores >= max_score)
        {
            if (player2.GetComponent<Paddle>().ia == true)
            {
                mess_winner.text += "\n Gana IA 2";
            }
            else
            {
                mess_winner.text += "\n Gana jugador 2";
            }
        }
        help.SetActive(true);
        //end = true;
    }
    public int getMaxScore()
    {
        return max_score;
    }
    public void Reset()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Paddle>().Reposition();
        player2.GetComponent<Paddle>().Reposition();
    }

    public void ReStart()
    {
        score_table.text = "0-0";
        mess_winner.text = "";
        help.SetActive(false);
        player1Scores = 0;
        player2Scores = 0;
        //end = false;
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Paddle>().Reset();
        player2.GetComponent<Paddle>().Reset();
    }

    public int getPlayer1Scores()
    {
        return player1Scores;
    }
    public int getPlayer2Scores()
    {
        return player2Scores;
    }
    public void setPlayer1Scores()
    {
        player1Scores++;
        if (player2.transform.localScale.y < maxPaddle)
        {
            player1.transform.localScale -= new Vector3(0, increasePaddle, 0);
            player2.transform.localScale += new Vector3(0, increasePaddle, 0);
        }
    }
    public void setPlayer2Scores()
    {
        player2Scores++;
        if (player1.transform.localScale.y < maxPaddle)
        {
            player1.transform.localScale += new Vector3(0, increasePaddle, 0);
            player2.transform.localScale -= new Vector3(0, increasePaddle, 0);
        }
    }

    void Awake()
    {

        this.fms = new FMS(this, GameObject.Find("Menu"), ball.GetComponent<Ball>());
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
        fms.Update();
    }
}
