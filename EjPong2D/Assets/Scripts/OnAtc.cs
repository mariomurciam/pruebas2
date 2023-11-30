using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAtc : State
{
    private AutoPaddleFSM fms;
    private Rigidbody2D ball;
    private Paddle paddle;
    public OnAtc(AutoPaddleFSM fms, Rigidbody2D ball, Paddle paddle)
    {
        this.fms = fms;
        this.ball = ball;
        this.paddle = paddle;
    }
    public void Enter()
    {
        paddle.onAtc = true;
    }

    public void Update()
    {
        if(paddle.isPlayer1){
            if (ball.velocity.x < 0)
            {
                fms.OnNext(fms.def);
            }
        }else{
            if (ball.velocity.x >= 0)
            {
                fms.OnNext(fms.def);
            }
        }
        
    }

    public void Exit()
    {

    }
}
