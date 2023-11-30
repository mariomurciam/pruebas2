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
        paddle.onAtc = false;
    }

    public void Update()
    {
        if(paddle.isPlayer1){
            if (ball.velocity.x >= 0)
            {
                fms.OnNext(fms.atc);
            }
        }else{
            if (ball.velocity.x < 0)
            {
                fms.OnNext(fms.atc);
            }
        }
    }

    public void Exit()
    {

    }
}
