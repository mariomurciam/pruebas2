using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDef : State
{
    private AutoPaddleFSM fms;
    private Rigidbody2D ball;
    private Paddle paddle;
    public OnDef(AutoPaddleFSM fms, Paddle paddle)
    {
        this.fms = fms;
        this.ball = paddle.ball.GetComponent<Rigidbody2D>();
        this.paddle = paddle;
    }
    public void Enter()
    {
        paddle.onAtc = false;
    }

    public void Update()
    {
        if (paddle.isPlayer1)
        {
            if (ball.velocity.x >= 0)
            {
                fms.OnNext(fms.atc);
            }
        }
        else
        {
            if (ball.velocity.x < 0)
            {
                fms.OnNext(fms.atc);
            }
        }
        if (paddle.rb.transform.position.y > 0.05f)
        {
            paddle.movement = -1f;
        }
        else if (paddle.rb.transform.position.y < -0.05f)
        {
            paddle.movement = 1f;
        }
        else
        {
            paddle.movement = 0f;
        }


    }

    public void Exit()
    {

    }
}
