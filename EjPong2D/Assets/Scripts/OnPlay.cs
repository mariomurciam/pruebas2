using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlay : State
{
    private FMS fms;
    public OnPlay(FMS fms)
    {
        this.fms = fms;
    }
    public void Enter() { Debug.Log("AAAAAAAAAAAA"); }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fms.OnPause();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            fms.QuitGame();
        }
        if (fms.gameManager.player1Scores >= fms.gameManager.getMaxScore() || fms.gameManager.player2Scores >= fms.gameManager.getMaxScore())
        {
            fms.OnWinner();
        }
    }
    public void Exit() { }
}
