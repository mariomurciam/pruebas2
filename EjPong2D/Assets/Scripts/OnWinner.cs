using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnWinner : State
{
    private FMS fms;
    public OnWinner(FMS fms){
        this.fms=fms;
    }
    public void Enter() { }
    public void Update() { }
    public void Exit() { }
}
