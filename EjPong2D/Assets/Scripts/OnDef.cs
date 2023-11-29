using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDef : State
{
    private AutoPaddleFSM fms;
    private Rigidbody2D ball;
    private Paddle paddle;
    public OnDef(AutoPaddleFSM fms, Rigidbody2D ball, Paddle paddle)
    {
        this.fms = fms;
        this.ball = ball;
        this.paddle = paddle;
    }

    public void Enter()
    {
        fms.gameManager.player2.GetComponent<Paddle>().onAtc = false;
    }

    public void Update()
    {
        if (ball.velocity.x < 0)
        {
            fms.OnNext(fms.atc);
        }
    }

    public void Exit()
    {

    }
}
