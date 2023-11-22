using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Wall;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game").GetComponentInParent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("GOOOOOL");

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            if (!isPlayer1Wall)
            {
                gameManager.setPlayer1Scores();
            }
            else
            {
                gameManager.setPlayer2Scores();
            }
            gameManager.Score();
        }
    }
}
