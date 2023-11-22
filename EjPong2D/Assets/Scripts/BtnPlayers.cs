using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnPlayers : MonoBehaviour
{
    [SerializeField] private Button btnPlayers;
    [SerializeField] private Button btnIA;
    [SerializeField] private GameObject player2;

	void Start () {
		btnPlayers.onClick.AddListener(TaskOnClickPlayers);
        btnIA.onClick.AddListener(TaskOnClickIA);
	}

    void TaskOnClickPlayers(){
		player2.GetComponent<Paddle>().ia = false;
        gameObject.SetActive(false);
	}
    void TaskOnClickIA(){
		player2.GetComponent<Paddle>().ia = true;
        gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
