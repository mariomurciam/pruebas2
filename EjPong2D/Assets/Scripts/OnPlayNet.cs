using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class OnPlayNet : State
{
    private FMS fms;
    public NetworkVariable<bool> netPause = new NetworkVariable<bool>();
    public OnPlayNet(FMS fms)
    {
        this.fms = fms;
    }
    public void Enter() { }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fms.gameManager.OnPauseClientRpc();
            fms.OnNext(fms.pauseNet);
            if (fms.gameManager.IsServer)
            {
                OnPauseClientRpc();
            }
            else
            {
                OnPauseServerRpc();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            fms.QuitGame();
        }
        if (fms.gameManager.player1Scores >= fms.gameManager.getMaxScore() || fms.gameManager.player2Scores >= fms.gameManager.getMaxScore())
        {
            fms.OnNext(fms.win);
        }
        if (fms.gameManager.newPoint == true)
        {
            fms.gameManager.newPoint = false;
            //fms.gameManager.OnPauseClientRpc();
            fms.OnNext(fms.pauseNet);
            if (fms.gameManager.IsServer)
            {
                OnPauseClientRpc();
            }
            else
            {
                OnPauseServerRpc();
            }
        }
    }
    public void Exit() { }

    
  
    void OnPauseClientRpc(){
        fms.gameManager.OnPauseClientRpc();
        Debug.Log("PPPPP");
    }
    public void OnPauseServerRpc(){
        fms.gameManager.OnPauseServerRpc();
    }
}
