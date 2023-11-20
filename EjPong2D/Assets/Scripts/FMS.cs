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
        OnPlay();
    }

    void Update(){
        now.Update();
    }

    public void OnPause()
    {
        Debug.Log("OnPause");
        now = pause;
        now.Enter();
    }

    public void OnPlay()
    {
        Debug.Log("OnPlay");
        now = play;
        now.Enter();
    }

    public void OnWinner()
    {
        Debug.Log("OnWinner");
        now = win;
        now.Enter();
    }

}
