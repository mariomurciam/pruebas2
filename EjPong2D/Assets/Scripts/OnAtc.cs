using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAtc : State
{
    private AutoPaddleFSM fms;
    private Rigidbody2D ball;
    public OnAtc(AutoPaddleFSM fms, Rigidbody2D ball)
    {
        this.fms = fms;
        this.ball = ball;
    }
    public void Enter()
    {
        fms.gameManager.player2.GetComponent<Paddle>().onAtc = true;
    }

    public void Update()
    {
        if (ball.velocity.x >= 0)
        {
            fms.OnDef();
        }
    }

    public void Exit()
    {

    }
}
