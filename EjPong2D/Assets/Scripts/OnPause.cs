using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : State
{
    private FMS fms;
    public OnPause(FMS fms){
        this.fms=fms;
    }
    public void Enter()
    {
        Pause();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            fms.OnPlay();
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    void Exit() { }
}
