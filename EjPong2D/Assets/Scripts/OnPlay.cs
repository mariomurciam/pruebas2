using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : State
{
    private FMS fms;
    public OnPlay(FMS fms){
        this.fms=fms;
    }
    public void Enter() { Debug.Log("AAAAAAAAAAAA");}
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            fms.OnPause();
        }
    }
    public void Exit() { }
}
