using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAtc : State
{
    private AutoPaddleFSM fms;
    private Rigidbody2D ball;
    private Paddle paddle;

    public OnAtc(AutoPaddleFSM fms, Paddle paddle)
    {
        this.fms = fms;
        this.ball = paddle.ball.GetComponent<Rigidbody2D>();
        this.paddle = paddle;
    }
    public void Enter()
    {
        paddle.onAtc = true;
    }

    public void Update()
    {
        if (paddle.isPlayer1)
        {
            if (ball.velocity.x < 0)
            {
                fms.OnNext(fms.def);
            }
        }
        else
        {
            if (ball.velocity.x >= 0)
            {
                fms.OnNext(fms.def);
            }
        }

        if (ball.transform.position.y > paddle.rb.transform.position.y)
        {
            paddle.movement = 1f;

        }
        else
        {
            if (ball.transform.position.y < paddle.rb.transform.position.y)
            {
                paddle.movement = -1f;
            }
            else
            {
                paddle.movement = 0f;
            }

        }
        //ball.velocity = new Vector2(0, paddle.movement * paddle.speed);

    }

    public void Exit()
    {

    }
}
