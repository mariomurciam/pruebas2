using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Unity.Netcode;

public class OnPauseNet : State
{
    private FMS fms;
    private Ball ball;
    public OnPauseNet(FMS fms, Ball ball)
    {
        this.fms = fms;
        this.ball = ball;
    }
    public void Enter()
    {
        Debug.Log("PAUSE");
        Time.timeScale = 0;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fms.OnNext(fms.playNet);
            //fms.gameManager.OnPlayClientRpc();
            if (fms.gameManager.IsServer)
            {
                OnPlayClientRpc();
            }
            else
            {
                OnPlayServerRpc();
            }
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        if (fms.gameManager.IsServer)
        {
            if (ball.rb.velocity == Vector2.zero)
            {
                ball.Launch();
            }
        }
        else
        {
            LaunchServerRpc();
        }
    }


    public void LaunchServerRpc()
    {
        fms.gameManager.LaunchServerRpc();
    }


    void OnPlayClientRpc()
    {
        fms.gameManager.OnPlayClientRpc();
    }


    public void OnPlayServerRpc()
    {
        fms.gameManager.OnPlayServerRpc();
    }


}
