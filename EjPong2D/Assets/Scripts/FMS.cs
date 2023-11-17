using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMS : MonoBehaviour
{
    private State play;
    private State pause;
    private State win;

    void Start()
    {
        play = new OnPlay();
        pause = new OnPause();
        win = new OnWinner();
    }

    public void OnPause()
    {

    }

    void OnPlay()
    {

    }

    void OnWinner()
    {

    }

}
