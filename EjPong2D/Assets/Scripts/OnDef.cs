using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDef : State
{
    private AutoPaddleFSM fms;
    private Rigidbody2D ball;
    public OnDef(AutoPaddleFSM fms, Rigidbody2D ball)
    {
        this.fms = fms;
        this.ball = ball;
    }

    public void Enter()
    {
        fms.gameManager.player2.GetComponent<Paddle>().onAtc = false;
    }

    public void Update()
    {
        if (ball.velocity.x < 0)
        {
            fms.OnAtc();
        }
    }

    public void Exit()
    {

    }
}
