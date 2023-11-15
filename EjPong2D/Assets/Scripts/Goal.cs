using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("GOOOOOL");

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            if (!isPlayer1Wall)
            {
                GameObject.Find("Game").GetComponentInParent<GameManager>().setPlayer1Scores();
            }
            else
            {
                GameObject.Find("Game").GetComponentInParent<GameManager>().setPlayer2Scores();
            }
            GameObject.Find("Game").GetComponentInParent<GameManager>().Score();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
