using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button btnPlayers;
    [SerializeField] private Button btnIA;
    [SerializeField] private Button btnSimulation;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    private Paddle paddle1;
    private Paddle paddle2;

    void Start()
    {
        btnPlayers.onClick.AddListener(TaskOnClickPlayers);
        btnIA.onClick.AddListener(TaskOnClickIA);
        btnSimulation.onClick.AddListener(TaskOnClickSimulation);
        paddle1 = player1.GetComponent<Paddle>();
        paddle2 = player2.GetComponent<Paddle>();
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
        paddle2.ia = true;
        gameObject.SetActive(false);
    }
    void TaskOnClickSimulation(){
        paddle1.ia = true;
        paddle2.ia = true;
        gameObject.SetActive(false);
    }
}
