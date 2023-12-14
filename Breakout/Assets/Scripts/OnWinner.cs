using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWinner : State
{
    private FMS fms;
    public OnWinner(FMS fms)
    {
        this.fms = fms;
    }
    public void Enter()
    {
        //fms.gameManager.Winner();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            fms.QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            fms.OnNext(fms.menu);
        }
    }
    public void Exit()
    {
        //fms.gameManager.ReStart();
    }
}
