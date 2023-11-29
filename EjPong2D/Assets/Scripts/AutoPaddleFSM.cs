using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoPaddleFSM
{
    public State def;
    public State atc;
    private State now;
    public GameObject ball;
    public GameManager gameManager;
    // Start is called before the first frame update
    public AutoPaddleFSM()
    {
        def = new OnDef(this, ball.GetComponent<Rigidbody2D>(), gameManager.player2.GetComponent<Paddle>());
        atc = new OnAtc(this, ball.GetComponent<Rigidbody2D>(), gameManager.player2.GetComponent<Paddle>());
        gameManager = ball.GetComponentInParent<GameManager>();
        now = def;
        now.Enter();
    }

    // Update is called once per frame
    public void Update()
    {
        now.Update();
        //Debug.Log("!!!!!!" + ball.GetComponent<Rigidbody2D>().velocity.x);
    }

    public void OnNext(State next)
    {
        now.Exit();
        now = next;
        now.Enter();
    }
}
