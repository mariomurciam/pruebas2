using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : State
{
    private FMS fms;
    private Ball ball;
    public OnPause(FMS fms, Ball ball)
    {
        this.fms = fms;
        this.ball = ball;
    }
    public void Enter()
    {
        Time.timeScale = 0;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fms.OnNext(fms.play);
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        if (ball.rb.velocity == Vector2.zero)
        {
            ball.Launch();
        }
    }
}
