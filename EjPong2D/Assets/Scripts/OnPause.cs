using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : State
{
    private FMS fms;
    public OnPause(FMS fms)
    {
        this.fms = fms;
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
    }
}
