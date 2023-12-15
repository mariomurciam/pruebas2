using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.Netcode;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button btnPlayers;
    [SerializeField] private Button btnIA;
    [SerializeField] private Button btnSimulation;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private Button btnClient;
    [SerializeField] private Button btnHost;
    [SerializeField] private Button btnExit;

    private Paddle paddle1;
    private Paddle paddle2;
    public GameManager gm;

    void Start()
    {
        btnPlayers.onClick.AddListener(TaskOnClickPlayers);
        btnIA.onClick.AddListener(TaskOnClickIA);
        btnSimulation.onClick.AddListener(TaskOnClickSimulation);
        paddle1 = player1.GetComponent<Paddle>();
        paddle2 = player2.GetComponent<Paddle>();
        btnClient.onClick.AddListener(TaskOnClickClient);
        btnHost.onClick.AddListener(TaskOnClickServer);
        btnExit.onClick.AddListener(QuitGame);
    }

    void TaskOnClickServer()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
        //gm.StartHost();
    }
    void TaskOnClickClient()
    {
        //gm.StartClient();
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);
    }

    void TaskOnClickPlayers()
    {
        paddle1.ia = false;
        paddle2.ia = false;
        gameObject.SetActive(false);
    }
    void TaskOnClickIA()
    {
        paddle1.ia = false;
        paddle2.StartIA();
        gameObject.SetActive(false);
    }
    void TaskOnClickSimulation()
    {
        paddle1.StartIA();
        paddle2.StartIA();
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
