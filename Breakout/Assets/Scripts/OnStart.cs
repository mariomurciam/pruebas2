using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStart : State
{
    private FMS fms;
    private Ball ball;
    public OnStart(FMS fms, Ball ball)
    {
        this.fms = fms;
        this.ball = ball;
    }
    public void Enter()
    {

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ball.Launch();
            fms.OnNext(fms.play);
        }
    }
    public void Exit()
    {

    }
}
