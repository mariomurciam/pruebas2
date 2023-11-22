using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMS : MonoBehaviour
{
    private State play;
    private State pause;
    private State win;
    private State now;

    void Start()
    {
        play = new OnPlay(this);
        pause = new OnPause(this);
        win = new OnWinner(this);
        now = play;
    }

    void Update(){
        now.Update();
    }

    public void OnPause()
    {
        now.Exit();
        now = pause;
        now.Enter();
        Debug.Log("OnPause");
    }

    public void OnPlay()
    {
        now.Exit();
        now = play;
        now.Enter();
        Debug.Log("OnPlay");
    }

    public void OnWinner()
    {
        now.Exit();
        now = win;
        now.Enter();
        Debug.Log("OnWinner");
    }

}
