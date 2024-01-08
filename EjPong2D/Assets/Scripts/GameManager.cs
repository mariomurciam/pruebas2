using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Unity.Netcode;
using Unity.Mathematics;

public class GameManager : NetworkBehaviour
{
    public GameObject ball;
    public GameObject prefabPlayer1;
    public GameObject prefabPlayer2;
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
    //public NetworkVariable<bool> netPause = new NetworkVariable<bool>();
    //public bool pause = true;
    //public NetworkVariable<string> netScore = new NetworkVariable<string>();
    public NetworkVariable<int> netScore1 = new NetworkVariable<int>();
    public NetworkVariable<int> netScore2 = new NetworkVariable<int>();

    public void StartHost()
    {
        GameObject newplayer1 = Instantiate(prefabPlayer1, player1.transform.position, Quaternion.identity);
        newplayer1.GetComponent<NetworkObject>().Spawn(true);
        player1.SetActive(false);
        player2.SetActive(false);
        player1 = newplayer1;
    }

    public override void OnNetworkSpawn()
    {
        if (!IsServer)
        {
            StartClientServerRpc(NetworkManager.Singleton.LocalClientId);
        }
        else
        {
            StartHost();
        }
    }
    


    [ServerRpc(RequireOwnership = false)]
    public void OnPlayServerRpc(){
        Debug.Log("ONPLAYSERVER");
        fms.OnNext(fms.playNet);
    }
    [ServerRpc(RequireOwnership = false)]
    public void OnPauseServerRpc(){
        Debug.Log("ONPAUSESERVER");
        fms.OnNext(fms.pauseNet);
    }

    [ClientRpc]
    public void OnPlayClientRpc(){
        Debug.Log("ONPLAYCLIENT");
        fms.OnNext(fms.playNet);
    }
    [ClientRpc]
    public void OnPauseClientRpc(){
        Debug.Log("ONPAUSECLIENT");
        fms.OnNext(fms.pauseNet);
    }

    [ServerRpc(RequireOwnership = false)]
    public void LaunchServerRpc(){
        Debug.Log("LAUNCH");
        Debug.Log(ball.GetComponent<Ball>().rb.velocity );
        if (ball.GetComponent<Ball>().rb.velocity == Vector2.zero)
        {
            ball.GetComponent<Ball>().Launch();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void StartClientServerRpc(ulong clientIP)
    {
        if (!IsServer && IsClient)
        {
            //Llamo a serverRpc
        }
        else
        {
            //Hago el cambio directamente
        }
        GameObject newplayer2 = Instantiate(prefabPlayer2, player2.transform.position, Quaternion.identity);
        newplayer2.GetComponent<NetworkObject>().SpawnWithOwnership(clientIP, true);
        player2 = newplayer2;
    }

    public void Score()
    {
        if (!IsServer && IsClient)
        {
            //Llamo a serverRpc
        }
        if (IsServer && !IsClient)
        {
            //Llamo a serverRpc
        }
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
